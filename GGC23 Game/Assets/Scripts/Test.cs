using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    private Vector3 m_objective;
    public int m_testVar;
    [SerializeField] private int m_testInt;
    float m_testFloat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsMouse();
        //Debug.Log("Hola");
    }
    private void RotateTowardsMouse()
    {
        //m_objective = m_camera.ScreenToWorldPoint(Input.mousePosition);
        //float m_anlgeRadians = Mathf.Atan2(m_objective.y - transform.position.y, m_objective.x - transform.position.x);
        //float m_angleDegrees = (180 / Mathf.PI) * m_anlgeRadians - 90;
        //transform.rotation = Quaternion.Euler(0, 0, m_angleDegrees);
    }
}
