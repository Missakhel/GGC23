using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragmenter : MonoBehaviour
{
  // Start is called before the first frame update
  public int m_score;

  public Vector3 m_originalPrefabScale;
  public int m_divideLimit = 3;
  public int m_divideCount = 3;
  public float m_childCoefficient = .75f;
  float m_currentScaleTime;
  public float m_scaleTimer = 1.0f;

  public Vector2 m_timeRange;
  Vector2 m_direction;

  GameObject m_instanceChild;

  private void Awake()
  {
    m_currentScaleTime = m_scaleTimer;
    m_originalPrefabScale = transform.localScale;
    transform.localScale = Vector3.zero;
    GetComponent<BoxCollider2D>().enabled = false;
    GetComponent<Wander>().enabled = false;
    GetComponent<Steering>().enabled = false;
  }

  // Update is called once per frame
  void Update()
    {
    if (m_currentScaleTime <= 0)
    {
      GetComponent<BoxCollider2D>().enabled = true;
      GetComponent<Wander>().enabled = true;
      GetComponent<Steering>().enabled = true;
      //Code goes here.
    }
    else
    {
      transform.localScale = m_originalPrefabScale * ((m_scaleTimer - m_currentScaleTime) / m_scaleTimer);
      m_currentScaleTime -= Time.deltaTime;
    }
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.CompareTag("Projectile"))
    {
      FindObjectOfType<SpawnArea>().m_currentScore += m_score;
      if(m_divideLimit > 0)
      {
        for (int i = 0; i < m_divideCount; i++)
        {
          m_instanceChild = Instantiate(gameObject, transform.position, Quaternion.identity);
          m_instanceChild.GetComponent<Fragmenter>().m_originalPrefabScale *= m_childCoefficient;
          m_instanceChild.GetComponent<Steering>().m_maxVel *= 2 - m_childCoefficient;
          m_instanceChild.GetComponent<Fragmenter>().m_score *= 2 - (int)m_childCoefficient;
          m_instanceChild.GetComponent<Fragmenter>().m_divideLimit --;
        }
      }
      Destroy(col);
      Destroy(gameObject);
    }
  }

  void ChangeDirection()
  {

  }
}
