using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State
{
    Vector3 direction;
    Vector3 direction2;
    Vector3 direction3;
    Vector3 direction4;
    float Vel;
    // Start is called before the first frame update
    public override void OnEnter()
    {
        direction = new Vector2(-1f, 0f);
        direction2 = new Vector2(1f, 0f);
        direction3 = new Vector2(0f, 1f);
        direction4 = new Vector2(0f, -1f);
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += direction *Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += direction2 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += direction3 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += direction4 * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            m_statemachine.SetState(m_statemachine.m_Idle);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            m_statemachine.SetState(m_statemachine.m_Idle);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            m_statemachine.SetState(m_statemachine.m_Idle);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            m_statemachine.SetState(m_statemachine.m_Idle);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_statemachine.SetState(m_statemachine.m_Run);
        }
    }
    public override void OnExit()
    {
       
    }
}
