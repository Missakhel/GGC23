using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Idle : State
{
    // Start is called before the first frame update
    public override void OnEnter()
    {

    }

  // Update is called once per frame
  public override void OnUpdate(){
    if (Input.GetKey(KeyCode.A)){
            m_statemachine.SetState(m_statemachine.m_Walk); 
        }
        if (Input.GetKey(KeyCode.D))
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_statemachine.SetState(m_statemachine.m_Run);
        }
    }
    public override void OnExit()
    {
        
    }
}
