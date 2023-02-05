using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniShroom : MonoBehaviour
{
  public Vector2 m_dir;
  public float m_sporeReviveTime;
  public GameObject m_spore;
  public GameObject m_deadZone;
  public GameObject m_parent;

  SpriteRenderer m_renderer;
  public Vector3 m_bounceAmount;
  public float m_maxOffMagnitude;

  public bool m_outOfBounds = false;

  //Shake Vars
  public int m_shakeCycles = 10;
  public float m_blinkDuration = 0.125f;
  float m_blinkTimeCounter = 0.0f;
  [HideInInspector] public bool m_isBlinking = false;

  private void Awake()
  {
    m_renderer = GetComponentInChildren<SpriteRenderer>();
  }

  public GameObject S_MuerteHijo;
  public GameObject S_HijoRevive;
  
  // Start is called before the first frame update
  void Start()
  {
    GetComponent<Live>().onDie += OnDie;
    m_spore.GetComponent<Spore>().m_miniMushroom = gameObject;
    m_parent.GetComponent<Shroom>().onDie += kill;
    //GetComponent<Rigidbody2D>().velocity = m_dir.normalized * m_maxVel;
  }

  // Update is called once per frame
  void Update()
  {
    Blink();
    if (gameObject.transform.position.x > 10)
    {
      m_outOfBounds = true;
      var vel = GetComponent<Rigidbody2D>().velocity;
      GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * GetComponent<Steering>().m_maxVel;
      GetComponent<Steering>().enabled = false;
    }
    else if (gameObject.transform.position.x < -10)
    {
      m_outOfBounds = true;
      var vel = GetComponent<Rigidbody2D>().velocity;
      GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * GetComponent<Steering>().m_maxVel;
      GetComponent<Steering>().enabled = false;
    }
    else if (gameObject.transform.position.y > 7)
    {
      m_outOfBounds = true;
      var vel = GetComponent<Rigidbody2D>().velocity;
      GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * GetComponent<Steering>().m_maxVel;
      GetComponent<Steering>().enabled = false;
    }
    else if (gameObject.transform.position.y < -7)
    {
      m_outOfBounds = true;
      var vel = GetComponent<Rigidbody2D>().velocity;
      GetComponent<Rigidbody2D>().velocity = new Vector2(0,1) * GetComponent<Steering>().m_maxVel;
      GetComponent<Steering>().enabled = false;
    }
    else
    {
      m_outOfBounds = false;
      GetComponent<Steering>().enabled = true;
    }
    Debug.Log(m_outOfBounds);
  }

  public void StartBlink(float multiplier)
  {
    m_isBlinking = true;
    m_renderer.color = Color.red;
    m_blinkTimeCounter = 0.0f;
  }

  private void Blink()
  {
    if (m_isBlinking)
    {
      m_blinkTimeCounter += Time.deltaTime;
      if (m_blinkTimeCounter >= m_blinkDuration)
      {
        m_isBlinking = false;
        m_renderer.color = Color.white;
      }
    }
  }

  public void OnTriggerEnter2D(Collider2D col)
  {

    if (col.gameObject.CompareTag("Wall"))
    {
      if (!m_outOfBounds)
      {
        var normal = col.GetComponent<Wall>().m_normal;
        var newVel = Vector3.Reflect(GetComponent<Rigidbody2D>().velocity, normal);
        if (GetComponent<Wander>().enabled)
        {
          GetComponent<Wander>().changeVel(newVel);
        }
      }
    }
    if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("EnemyProjectile"))
    {
      
      GetComponent<Live>().Damage(1);
      Instantiate(S_MuerteHijo);
    }
    if (col.gameObject.CompareTag("Shroom"))
    {
      Debug.Log("returned to parent " + col.name);
      GetComponent<Follow>().enabled = true;
      GetComponent<Wander>().enabled = false;
      GetComponent<CircleCollider2D>().enabled = false;
      m_parent.GetComponent<Shroom>().addChild(gameObject);
    }

    
  }

  void OnDie()
  {
    m_spore.transform.position = transform.position;
    GetComponent<Follow>().enabled = false;
    GetComponent<Wander>().enabled = false;
    GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
    transform.position = m_deadZone.transform.position;
  }
  public void OnRevive()
  {
    GetComponent<Live>().hp = 1;
    transform.position = m_spore.transform.position;
    GetComponent<Follow>().enabled = true;
    m_spore.transform.position = m_deadZone.transform.position;
    Instantiate(S_HijoRevive);
  }

  public void kill()
  {
    Destroy(m_spore);
    Destroy(gameObject);
  }

  public void activateCollider()
  {
    GetComponent<CircleCollider2D>().enabled = true;
  }
  public void activateColliderAfterTime(float time)
  {
    Invoke("activateCollider", time);
  }
}
