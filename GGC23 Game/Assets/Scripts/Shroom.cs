using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : MonoBehaviour
{

  public float m_damageForse = 1;

  public GameObject m_child;

  bool m_farFromParent = false;
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnTriggerEnter2D(Collider2D col)
  {
    
    
    if (!col.gameObject.CompareTag("Enemy"))
    {
      return;
    }
    
    var vel3D = (transform.position - col.transform.position).normalized * m_damageForse;
    var vel2D = new Vector2(vel3D.x, vel3D.y);
    GetComponent<Rigidbody2D>().velocity = vel2D;
    Debug.Log("is alive? " + m_child.GetComponent<Live>().isDead());
    if (!m_child.GetComponent<Live>().isDead())
    {
      Debug.Log("went away");
      m_child.GetComponent<Follow>().enabled = false;
      m_child.GetComponent<Wander>().enabled = true;
      m_child.GetComponent<Wander>().changeVel(vel2D);
    }

    
    //var child = Instantiate(m_child, transform.position, transform.rotation);
    //child.GetComponent<MiniShroom>().m_dir = Vel2D;
    //child.GetComponent<MiniShroom>().setDir(Vel2D);
  }
}
