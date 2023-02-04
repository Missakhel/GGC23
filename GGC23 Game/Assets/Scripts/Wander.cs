using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
  public float m_wanderRadius;
  public float m_wanderDistance;
  public float m_wanderTime;
  float m_time;
  Vector2 m_newVel;
  // Start is called before the first frame update
  void Start()
  {
    m_time = m_wanderTime;
  }

  // Update is called once per frame
  void Update()
  {
    m_time += Time.deltaTime;
    if(m_time > m_wanderTime)
    {
      m_time -= m_wanderTime;
      var pos2D = new Vector2(transform.position.x, transform.position.y);
      m_newVel = GetComponent<Rigidbody2D>().velocity.normalized * m_wanderDistance + Random.insideUnitCircle.normalized* m_wanderRadius;
    }

    GetComponent<Steering>().m_wantedVel = m_newVel;
  }

  public void changeVel(Vector2 newVel)
  {
    m_newVel = newVel;
    m_time = 0;
  }
}
