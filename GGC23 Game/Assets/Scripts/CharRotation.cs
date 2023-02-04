using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CharRotation : MonoBehaviour
{
  [SerializeField] private Camera m_camera;
  private Vector3 m_objective;
  public GameObject m_bulletPrefab;
  public Transform m_spawner;
  public float m_bulletLife = 5f;
  public float m_bulletVelocity = 5f;
  public float m_bulletSize = 1;
  public float m_grados = 1;
  Vector3 directionv;
  GameObject m_bulletInstance;
  public float m_spawnTimer = .33f;
  float m_currentSpawnTime;
  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    ShootingArrows();
        //Checkfiring();
        //RotateTowardsMouse();
    }
  private void ShootingArrows()
  {
    directionv = (m_objective - transform.position);
    float m_anlgeRadians = Mathf.Atan2(directionv.y, directionv.x);
    float m_angleDegrees = (180 / Mathf.PI) * m_anlgeRadians - 90;
    var m_pointD = Quaternion.Euler(0, 0, m_angleDegrees);
    void m_printShoot()
    {
      if (m_currentSpawnTime <= 0)
      {
        m_bulletInstance = Instantiate(m_bulletPrefab);
        m_bulletInstance.transform.position = m_spawner.position;
        m_bulletInstance.GetComponent<Rigidbody2D>().transform.localScale *= m_bulletSize;
        m_bulletInstance.GetComponent<Rigidbody2D>().velocity = (m_spawner.position - transform.position) * m_bulletVelocity;
        m_currentSpawnTime = m_spawnTimer;
        Destroy(m_bulletInstance, m_bulletLife);
      }
      else
      {
        m_currentSpawnTime -= Time.deltaTime;
      }
    }
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      m_pointD = Quaternion.Euler(0, 0, 0);
      m_printShoot();
      transform.rotation = m_pointD;
    }
    if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.RightArrow)))
    {
      m_pointD = Quaternion.Euler(0, 0, -45);
      m_printShoot();
      transform.rotation = m_pointD;
    }
    if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftArrow)))
    {
      m_pointD = Quaternion.Euler(0, 0, 45);
      m_printShoot();
      transform.rotation = m_pointD;
    }
    if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.RightArrow)))
    {
      m_pointD = Quaternion.Euler(0, 0, -135);
      m_printShoot();
      transform.rotation = m_pointD;
    }
    if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftArrow)))
    {
      m_pointD = Quaternion.Euler(0, 0, 135);
      m_printShoot();
      transform.rotation = m_pointD;
    }
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      m_pointD = Quaternion.Euler(0, 0, -180);
      m_printShoot();
      transform.rotation = m_pointD;
    }
    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      m_pointD = Quaternion.Euler(0, 0, -90);
      m_printShoot();
      transform.rotation = m_pointD;
    }
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      m_pointD = Quaternion.Euler(0, 0, 90);
      m_printShoot();
      transform.rotation = m_pointD;
    }
  }
  private void RotateTowardsMouse()
  {
    m_objective = m_camera.ScreenToWorldPoint(Input.mousePosition);
    directionv = (m_objective - transform.position);
    float m_anlgeRadians = Mathf.Atan2(directionv.y, directionv.x);
    float m_angleDegrees = m_grados = (180 / Mathf.PI) * m_anlgeRadians - 90;
    var m_pointD = Quaternion.Euler(0, 0, m_angleDegrees);
    transform.rotation = m_pointD;
    Dictionary<float, float[] > map = new Dictionary<float, float[]>()
    {
      { 0, new float[] {-22.5f,22.5f }},{45,new float[]{22.5f,68f } },{90,new float[]{68f,112.5f} }
    };

    float[] floatArray = new float[] {0, 2, 3};
    //if (m_grados <= 36&&m_grados >=-36)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, 0);
    //}
    //if(m_grados <=-36 && m_grados >= -72)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, -45);
    //}
    //if (m_grados <= -72 && m_grados >= -108)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, -90);
    //}
    //if (m_grados <= -108 && m_grados >= -144)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, -135);
    //}
    //if (m_grados <= -180 && m_grados >= -216)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, 180);
    //}
    //if(m_grados <= -216 && m_grados >= -255)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, 135);
    //}
    //if (m_grados <= -255 && m_grados >= -280)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, 90);
    //}
    //if(m_grados <= -280 && m_grados >= -360)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, 45);
    //}
    //    transform.rotation = m_pointD;
    }
    private void Checkfiring()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject m_bullet = Instantiate(m_bulletPrefab);
            m_bullet.transform.position = m_spawner.position;
            m_bullet.GetComponent<Rigidbody2D>().transform.localScale *= m_bulletSize;
            m_bullet.GetComponent<Rigidbody2D>().velocity = (m_spawner.position - transform.position)*m_bulletVelocity;
            Destroy(m_bullet, m_bulletLife);
        }
    }
}
