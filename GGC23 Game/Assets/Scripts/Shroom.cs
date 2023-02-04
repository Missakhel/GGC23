using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : MonoBehaviour
{

  public float m_damageForse = 1;

  public List<GameObject> m_childs;

  //bool m_farFromParent = false;
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {

  }

  //private void OnCollisionEnter2D(Collision2D collision)
  //{
  //  Debug.Log("collided "+ collision);
  //  //col
  //}

  void OnTriggerEnter2D(Collider2D col)
  {

    //if (col.gameObject.CompareTag("Wall"))
    //{
    //  GetComponent<Rigidbody2D>().get
    //}
    if (!col.gameObject.CompareTag("Enemy"))
    {
      return;
    }
    
    var vel3D = (transform.position - col.transform.position).normalized * m_damageForse;
    var vel2D = new Vector2(vel3D.x, vel3D.y);
    GetComponent<Rigidbody2D>().velocity = vel2D;

    foreach(var child in m_childs)
    {
      if (!child.GetComponent<Live>().isDead())
      {
        Debug.Log("went away");
        child.GetComponent<Follow>().enabled = false;
        child.GetComponent<Wander>().enabled = true;
        child.GetComponent<Wander>().changeVel(vel2D);
        child.GetComponent<CircleCollider2D>().enabled = true;
        m_childs.Remove(child);
        break;
      }
    }

    foreach (var child in m_childs)
    {
      child.GetComponent<Follow>().m_angle = 0;
    }


    //var child = Instantiate(m_child, transform.position, transform.rotation);
    //child.GetComponent<MiniShroom>().m_dir = Vel2D;
    //child.GetComponent<MiniShroom>().setDir(Vel2D);
  }

  public void addChild(GameObject child)
  {
    if (m_childs.Count == 0)
    {
      child.GetComponent<Follow>().m_angle = 0;
    }
    else
    {
      child.GetComponent<Follow>().m_angle = .5f;
      m_childs[0].GetComponent<Follow>().m_angle = -.5f;
    }
    m_childs.Add(child);
  }
}
