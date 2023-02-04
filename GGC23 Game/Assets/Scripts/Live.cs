using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : MonoBehaviour
{
  public float hp;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Damage(float dam)
  {
    hp -= dam;
    if (hp <= 0)
    {
      gameObject.GetComponent<CircleCollider2D>().enabled = false;
      Destroy(gameObject);
    }
  }
}


