using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniShroom : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    //GetComponent<Rigidbody2D>().velocity = m_dir.normalized * m_maxVel;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void setDir(Vector2 dir)
  {
    //GetComponent<Rigidbody2D>().velocity = 
  }

  public void OnTriggerEnter2D(Collider2D col)
  {
    
    if (col.gameObject.CompareTag("Wall"))
    {
      var normal = col.GetComponent<Wall>().m_normal;
      var newVel = Vector3.Reflect(GetComponent<Rigidbody2D>().velocity, normal);
      if (GetComponent<Wander>().enabled)
      {
        GetComponent<Wander>().changeVel(newVel);
      }
    }
    if (col.gameObject.CompareTag("Enemy"))
    {
      GetComponent<Live>().Damage(1);
    }
    if (col.gameObject.CompareTag("Shroom"))
    {
      Debug.Log("returned to parent");
      GetComponent<Follow>().enabled = true;
      GetComponent<Wander>().enabled = false;
    }
  }
}
