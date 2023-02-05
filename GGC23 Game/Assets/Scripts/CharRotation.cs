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
    //Debug.Log(directionv);
    if (directionv.magnitude > 0)
    {
      directionv.Normalize();
      m_printShoot();
    }
  }

  void m_printShoot()
  {
    if (m_currentSpawnTime <= 0)
    {
      m_bulletInstance = Instantiate(m_bulletPrefab);
      m_bulletInstance.transform.position = gameObject.transform.position;
      m_bulletInstance.GetComponent<Rigidbody2D>().transform.localScale *= m_bulletSize;
      m_bulletInstance.transform.localRotation = Quaternion.EulerAngles(0, 0, Vector3.Angle(transform.position, directionv + transform.position));
      //Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * m_pointD.x), Mathf.Sin(Mathf.Deg2Rad * m_pointD.y)) * m_bulletVelocity;
      m_bulletInstance.GetComponent<Rigidbody2D>().velocity = directionv * m_bulletVelocity;
      m_currentSpawnTime = m_spawnTimer;
      Destroy(m_bulletInstance, m_bulletLife);
    }
    else
    {
      m_currentSpawnTime -= Time.deltaTime;
    }
    //transform.rotation = m_pointD;
  }
}
