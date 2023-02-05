using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State
{
    public Vector2 m_dir;
    [SerializeField] public float m_vel =6f;
    // Start is called before the first frame update
    public override void OnEnter()
    {
        
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        float m_moveX = Input.GetAxisRaw("Horizontal");
        float m_moveY = Input.GetAxisRaw("Vertical");
        var newDir = new Vector3(m_moveX, m_moveY).normalized;
        var vel = m_dir * m_vel * Time.deltaTime;
        transform.position += new Vector3(vel.x,vel.y,0);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_statemachine.SetState(m_statemachine.m_Run);
        }
        if(newDir == Vector3.zero)
        {
            m_statemachine.SetState(m_statemachine.m_Idle);
        }
        else
        {
             m_dir = newDir;
        }
    }
    public override void OnExit()
    {
       
    }
}
