using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore : MonoBehaviour
{
  public float m_reviveTimer;
  public float m_currentReviveCountdown;
  public GameObject m_miniMushroom;

  // Start is called before the first frame update
  void Awake()
  {
    m_currentReviveCountdown = m_reviveTimer;
  }

  // Update is called once per frame
  void Update()
  {

  }

  //private void OnTriggerEnter2D(Collider2D collision)
  //{
  //  Debug.Log("spored");
  //}

  void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("SafeArea"))
    {
      if(m_currentReviveCountdown > 0)
      {
        m_currentReviveCountdown -= Time.deltaTime;
      }
      else
      {
        m_miniMushroom.GetComponent<MiniShroom>().OnRevive();
        //Instantiate(m_miniMushroom, transform.position, Quaternion.identity);
        //Destroy(gameObject);
      }
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    m_currentReviveCountdown = m_reviveTimer;
  }
}
