using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
  public Vector2 m_wantedVel;
  public float m_maxVel;
  public float m_maxAceleration;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    var m_realisticWantedVel = m_wantedVel.normalized * m_maxVel;
    var m_wantedAceleration = m_realisticWantedVel - GetComponent<Rigidbody2D>().velocity;
    var aceleration = Vector2.ClampMagnitude(m_wantedAceleration, m_maxAceleration);
    var newVel = Vector2.ClampMagnitude(GetComponent<Rigidbody2D>().velocity + aceleration, m_maxVel);
    GetComponent<Rigidbody2D>().velocity = newVel;
  }
}
