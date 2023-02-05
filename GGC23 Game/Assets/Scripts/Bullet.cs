using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    private Vector3 m_objective;
    private Rigidbody2D m_rigidbody;
    public float m_speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //m_objective = m_camera.ScreenToWorldPoint(Input.mousePosition);
        //m_rigidbody = GetComponent<Rigidbody2D>();
    }
}
