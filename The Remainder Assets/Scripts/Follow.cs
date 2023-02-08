using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
  public GameObject m_toFollow;

  public float m_distance;

  public float m_arrived;
  public float m_arriving;

  public float m_angle;

  //public GameObject m_debugPoint;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    var pos2D = new Vector2(m_toFollow.transform.position.x, m_toFollow.transform.position.y);
    var myPos2D = new Vector2(transform.position.x, transform.position.y);
    var vel2D = new Vector2(m_toFollow.GetComponent<Rigidbody2D>().velocity.x, m_toFollow.GetComponent<Rigidbody2D>().velocity.y);
    var playerDir3d = m_toFollow.GetComponent<Walk>().m_dir;//m_toFollow.GetComponent<CharRotation>().m_spawner.position- m_toFollow.transform.position;
    var playerDir2d = new Vector2(playerDir3d.x, playerDir3d.y);
    //Debug.Log(vel2D);
    //gameObject.transform.position = pos2D - vel2D.normalized * m_distance;

    var originalDir = playerDir2d.normalized;

    var dir = new Vector2(originalDir.x * Mathf.Cos(m_angle) - originalDir.y * Mathf.Sin(m_angle), originalDir.x * Mathf.Sin(m_angle) + originalDir.y * Mathf.Cos(m_angle));

    var placeToGo = pos2D - dir * m_distance;

    //placeToGo.
    //m_debugPoint.transform.position = placeToGo;
    var deltaPos = placeToGo - myPos2D;
    //m_debugPoint.transform.position = deltaPos;
    //Debug.Log(deltaPos.magnitude + " " + m_arrived);
    if(deltaPos.magnitude > m_arriving)
    {
      GetComponent<Steering>().m_wantedVel = deltaPos;
    }
    else if(deltaPos.magnitude > m_arrived)
    {
      GetComponent<Steering>().m_wantedVel = deltaPos*(deltaPos.magnitude-m_arrived) / (m_arriving- m_arrived);
    }
    else
    {
      GetComponent<Steering>().m_wantedVel = new Vector2(0, 0);
    }
  }
}
