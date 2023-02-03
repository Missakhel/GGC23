using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharRotation : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    private Vector3 m_objective;
    public GameObject m_bulletPrefab;
    public Transform m_spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Checkfiring();
        RotateTowardsMouse();
    }
    private void RotateTowardsMouse()
    {
        m_objective = m_camera.ScreenToWorldPoint(Input.mousePosition);
        float m_anlgeRadians = Mathf.Atan2(m_objective.y - transform.position.y, m_objective.x - transform.position.x);
        float m_angleDegrees = (180 / Mathf.PI) * m_anlgeRadians - 90;
        transform.rotation = Quaternion.Euler(0, 0, m_angleDegrees);
    }
    private void Checkfiring()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject m_bullet = Instantiate(m_bulletPrefab);
            m_bullet.transform.position = m_spawner.position;
            m_bullet.GetComponent<Rigidbody2D>().velocity = m_spawner.position - transform.position;
            Destroy(m_bullet, 5f);
        }
    }
}
