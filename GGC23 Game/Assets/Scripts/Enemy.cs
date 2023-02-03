using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public float speed;
    [HideInInspector] public int score;
    GameObject target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Shroom");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.CompareTag("Projectile"))
    {
      Destroy(gameObject);
      Destroy(col);
    }
  }
}
