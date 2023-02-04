using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
  public GameObject m_toFollow;

  public float m_distance;

  public float m_arrived;

  public GameObject m_debugPoint;
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
    var playerVel = new Vector2(m_toFollow.GetComponent<Walk>().m_dir.x, m_toFollow.GetComponent<Walk>().m_dir.y);
    //Debug.Log(vel2D);
    //gameObject.transform.position = pos2D - vel2D.normalized * m_distance;
    var placeToGo = pos2D - playerVel.normalized * m_distance;
    //m_debugPoint.transform.position = placeToGo;
    var deltaPos = placeToGo - myPos2D;
    //m_debugPoint.transform.position = deltaPos;
    Debug.Log(deltaPos.magnitude + " " + m_arrived);
    if(deltaPos.magnitude > m_arrived)
    {
      //Debug.Log("going");
      GetComponent<Steering>().m_wantedVel = deltaPos;
    }
    else
    {
      GetComponent<Steering>().m_wantedVel = new Vector2(0, 0);
    }
  }
}
