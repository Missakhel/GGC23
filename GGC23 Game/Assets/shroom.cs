using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shroom : MonoBehaviour
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
    if(col.name == "Spawn Area" || col.gameObject.CompareTag("Projectile"))
    {
      return;
    }
    Debug.Log(col.name + " shroomed");

    var vel3D = (transform.position - col.transform.position).normalized * m_damageForse;
    GetComponent<Rigidbody2D>().velocity = new Vector2(vel3D.x,vel3D.y);

    //Instantiate(m_child, transform.position, transform.rotation);
  }
}
