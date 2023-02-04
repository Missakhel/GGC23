using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : MonoBehaviour
{
  public GameObject m_child;

  public float m_damageForse = 1;
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
    Debug.Log("collided");
    if (col.name == "Spawn Area" || col.gameObject.CompareTag("Projectile"))
    {
      return;
    }
    Debug.Log("enemy hitted player");
    var vel3D = (transform.position - col.transform.position).normalized * m_damageForse;
    var Vel2D = new Vector2(vel3D.x, vel3D.y);
    GetComponent<Rigidbody2D>().velocity = Vel2D;

    var child = Instantiate(m_child, transform.position, transform.rotation);
    child.GetComponent<MiniShroom>().m_dir = Vel2D;
    //child.GetComponent<MiniShroom>().setDir(Vel2D);
  }
}
