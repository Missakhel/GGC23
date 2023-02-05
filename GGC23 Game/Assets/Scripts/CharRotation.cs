using System.Collections.Generic;
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
  Shroom m_shroomReference;
  Quaternion m_pointD;
  public float m_spawnTimer = .33f;
  float m_currentSpawnTime;
  bool m_otherKeyPressed;

  // Start is called before the first frame update
  void Awake()
  {
    m_pointD = Quaternion.Euler(0, 0, -135);
    m_shroomReference = FindObjectOfType<Shroom>();
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
    directionv = new Vector3(0, 0, 0);
    if (Input.GetKey(KeyCode.UpArrow))
    {
      directionv += new Vector3(0, 1, 0);
    }
    if (Input.GetKey(KeyCode.DownArrow))
    {
      directionv += new Vector3(0, -1, 0);
    }
    if (Input.GetKey(KeyCode.RightArrow))
    {
      directionv += new Vector3(1, 0, 0);
    }
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      directionv += new Vector3(-1, 0, 0);
    }
    Debug.Log(directionv);
    if (directionv.magnitude > 0)
    {
      directionv.Normalize();
      m_printShoot();
    }
    
    //directionv = (m_objective - transform.position);
    //float m_angleRadians = Mathf.Atan2(directionv.y, directionv.x);
    //float m_angleDegrees = (180 / Mathf.PI) * m_angleRadians - 90;
    //var m_pointD = Quaternion.Euler(0, 0, m_angleDegrees);
    //
    //if (Input.GetKey(KeyCode.UpArrow) && Input.GetAxis("Horizontal") == 0)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, 0);
    //  m_shroomReference.m_headRenderer.sprite = m_shroomReference.m_spriteN;
    //  m_printShoot();
    //}
    //if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
    //{
    //  m_pointD = Quaternion.Euler(0, 0, -45);
    //  m_shroomReference.m_headRenderer.sprite = m_shroomReference.m_spriteNE;
    //  m_printShoot();
    //}
    //if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
    //{
    //  m_pointD = Quaternion.Euler(0, 0, 45);
    //  m_shroomReference.m_headRenderer.sprite = m_shroomReference.m_spriteNW;
    //  m_printShoot();
    //}
    //if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
    //{
    //  m_pointD = Quaternion.Euler(0, 0, -135);
    //  m_shroomReference.m_headRenderer.sprite = m_shroomReference.m_spriteSE;
    //  m_printShoot();
    //}
    //if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
    //{
    //  m_pointD = Quaternion.Euler(0, 0, 135);
    //  m_shroomReference.m_headRenderer.sprite = m_shroomReference.m_spriteSW;
    //  m_printShoot();
    //}
    //if (Input.GetKey(KeyCode.DownArrow) && Input.GetAxis("Horizontal") == 0)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, -180);
    //  m_shroomReference.m_headRenderer.sprite = m_shroomReference.m_spriteS;
    //  m_printShoot();
    //}
    //if (Input.GetKey(KeyCode.RightArrow) && Input.GetAxis("Vertical") == 0)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, -90);
    //  m_shroomReference.m_headRenderer.sprite = m_shroomReference.m_spriteE;
    //  m_printShoot();
    //}
    //if (Input.GetKey(KeyCode.LeftArrow) && Input.GetAxis("Vertical") == 0)
    //{
    //  m_pointD = Quaternion.Euler(0, 0, 90);
    //  m_shroomReference.m_headRenderer.sprite = m_shroomReference.m_spriteW;
    //  m_printShoot();
    //}
  }

  void m_printShoot()
  {
    if (m_currentSpawnTime <= 0)
    {
      m_bulletInstance = Instantiate(m_bulletPrefab);
      m_bulletInstance.transform.position = m_spawner.position;
      m_bulletInstance.GetComponent<Rigidbody2D>().transform.localScale *= m_bulletSize;
      Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * m_pointD.x), Mathf.Sin(Mathf.Deg2Rad * m_pointD.y)) * m_bulletVelocity;
      m_bulletInstance.GetComponent<Rigidbody2D>().velocity = directionv* m_bulletVelocity;
      m_currentSpawnTime = m_spawnTimer;
      Destroy(m_bulletInstance, m_bulletLife);
    }
    else
    {
      m_currentSpawnTime -= Time.deltaTime;
    }
    //transform.rotation = m_pointD;
  }

  private void RotateTowardsMouse()
  {
    m_objective = m_camera.ScreenToWorldPoint(Input.mousePosition);
    directionv = (m_objective - transform.position);
    float m_anlgeRadians = Mathf.Atan2(directionv.y, directionv.x);
    float m_angleDegrees = m_grados = (180 / Mathf.PI) * m_anlgeRadians - 90;
    //var m_pointD = Quaternion.Euler(0, 0, m_angleDegrees);
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
