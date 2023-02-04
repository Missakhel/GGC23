using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
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
    if (isDead())
    {
      if (onDie != null)
      {
        onDie();
      }
      
      //Destroy(gameObject);
    }
  }

  public bool isDead()
  {
    return hp <= 0;
  }

  public event Action onDie;


}


