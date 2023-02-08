using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : State
{
    float LapsedTime;
    Vector3 direction;
    Vector3 direction2;
    Vector3 direction3;
    Vector3 direction4;
    public Vector3 m_dir;
    [SerializeField] float m_velRun = 12f;
    // Start is called before the first frame update
    public override void OnEnter()
    {
        LapsedTime = 0.0f;
        direction = new Vector3(-2f, 0f, 0f);
        direction2 = new Vector3(2f, 0f, 0f);
        direction3 = new Vector2(0f, 2f);
        direction4 = new Vector2(0f, -2f);
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
            float m_moveX = Input.GetAxisRaw("Horizontal");
            float m_moveY = Input.GetAxisRaw("Vertical");
            m_dir = new Vector3(m_moveX, m_moveY);
            transform.position += m_dir * m_velRun * Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            m_statemachine.SetState(m_statemachine.m_Walk);
        }
        if (m_dir == Vector3.zero)
        {
            m_statemachine.SetState(m_statemachine.m_Idle);
        }
    }
    public override void OnExit()
    {
        
    }
}
