using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
  [HideInInspector] public float m_speed;
  public int m_score;
  public GameObject m_bulletPrefab;
  GameObject m_target;
  GameObject m_bulletInstance;

  Vector3 m_originalPrefabScale;
  float m_currentScaleTime;
  public float m_scaleTimer = 1.5f;
  public float m_shootCooldown = 1.0f;
  public float m_bulletSpeed = .5f;
  public float m_bulletLifetime = 2.5f;
  float m_currentCooldown;
  public GameObject S_ColisionEnemigo;

  // Start is called before the first frame update
  void Awake()
  {
    m_currentScaleTime = m_scaleTimer;
    m_currentCooldown = m_shootCooldown;
    m_originalPrefabScale = transform.localScale;
    transform.localScale = Vector3.zero;
    m_target = GameObject.FindGameObjectWithTag("Shroom");
    GetComponent<CircleCollider2D>().enabled = false;
  }

    // Update is called once per frame
    void Update()
    {
      if (m_currentScaleTime <= 0)
      {
        GetComponent<CircleCollider2D>().enabled = true;
        transform.right = m_target.transform.position - transform.position;

      if (m_currentCooldown <= 0)
        {
          m_bulletInstance = Instantiate(m_bulletPrefab, transform.position, transform.localRotation);
          m_bulletInstance.GetComponent<Rigidbody2D>().velocity = (m_target.transform.position - transform.position).normalized * m_bulletSpeed;
          Destroy(m_bulletInstance, m_bulletLifetime);
          m_currentCooldown = m_shootCooldown;
        }
        else
        {
          m_currentCooldown -= Time.deltaTime;
        }
      }
      else
      {
        transform.localScale = m_originalPrefabScale * ((m_scaleTimer - m_currentScaleTime) / m_scaleTimer);
        m_currentScaleTime -= Time.deltaTime;
      }

      if (!m_target)
      {
        Destroy(gameObject);
      }
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.CompareTag("Projectile"))
    {
      Instantiate(S_ColisionEnemigo);
      FindObjectOfType<SpawnArea>().m_currentScore += m_score;
      Destroy(col);
      Destroy(gameObject);
    }
  }
}
