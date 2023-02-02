using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public FSM m_statemachine;
    virtual public void OnEnter(){

    }
    virtual public void OnExit(){

    }
    virtual public void OnUpdate(){

    }
    virtual public void OnCollisionE(Collision2D collision)
    {
        
    }
    virtual public void OntriggerS(Collider2D collision)
    {

    }
    virtual public void OntriggerEx(Collider2D collision)
    {

    }
    public void SetFSM(FSM SM){
        m_statemachine = SM;
    }
    private void Awake()
    {
       
    }
}
