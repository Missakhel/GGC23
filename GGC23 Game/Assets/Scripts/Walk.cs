using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State
{
    Vector3 direction;
    Vector3 direction2;
    Vector3 direction3;
    Vector3 direction4;
    public Vector3 m_dir;
    [SerializeField] public float m_vel =2f;
    // Start is called before the first frame update
    public override void OnEnter()
    {
        direction = new Vector2(-1, 0f);
        direction2 = new Vector2(1f, 0f);
        direction3 = new Vector2(0f, 1f);
        direction4 = new Vector2(0f, -1f);
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        float m_moveX = Input.GetAxisRaw("Horizontal");
        float m_moveY = Input.GetAxisRaw("Vertical");
        m_dir = new Vector3(m_moveX, m_moveY);
        transform.position += m_dir * m_vel*Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_statemachine.SetState(m_statemachine.m_Run);
        }
        if(m_dir == Vector3.zero)
        {
            m_statemachine.SetState(m_statemachine.m_Idle);
        }
    }
    public override void OnExit()
    {
       
    }
}
