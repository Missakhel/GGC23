using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [HideInInspector] public float m_speed;
  public int m_score;
  GameObject m_target;

  Vector3 m_originalPrefabScale;
  float m_currentScaleTime;
  public float m_scaleTimer = 1.0f; //Counts the time it will take the enemy to reach its full size

  private void Awake()
  {
    m_target = GameObject.Find("Shroom");
    m_currentScaleTime = m_scaleTimer;
    m_originalPrefabScale = transform.localScale;
    transform.localScale = Vector3.zero;
    GetComponent<CircleCollider2D>().enabled = false;
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    
    if (m_currentScaleTime <= 0)
    {
      GetComponent<CircleCollider2D>().enabled = true;
      transform.position = Vector2.MoveTowards(transform.position, m_target.transform.position, m_speed);
    }
    else
    {
      transform.localScale = m_originalPrefabScale * ((m_scaleTimer - m_currentScaleTime) / m_scaleTimer);
      m_currentScaleTime -= Time.deltaTime;
    }
  }

  /*private void OnCollisionEnter(Collision collision)
  {
      if(collision.gameObject.CompareTag("Projectile"))
      {
          Debug.Log("hit");
          Destroy(gameObject);
      }
  }*/

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.CompareTag("Projectile"))
    {
      FindObjectOfType<SpawnArea>().m_currentScore += m_score;
      Destroy(col);
      Destroy(gameObject);
    }
  }
}
