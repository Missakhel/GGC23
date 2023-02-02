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
    [SerializeField] float m_velRun = 0f;
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += direction2 * m_velRun* Time.deltaTime;
                LapsedTime += Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += direction * m_velRun* Time.deltaTime;
                LapsedTime += Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += direction3 * m_velRun* Time.deltaTime;
                LapsedTime += Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += direction4 * m_velRun * Time.deltaTime;
                LapsedTime += Time.deltaTime;
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            m_statemachine.SetState(m_statemachine.m_Walk);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_statemachine.SetState(m_statemachine.m_Walk);
        }
        if (Input.GetKey(KeyCode.W))
        {
            m_statemachine.SetState(m_statemachine.m_Walk);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_statemachine.SetState(m_statemachine.m_Walk);
        }
    }

    public override void OnExit()
    {
        
    }
}
