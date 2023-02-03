using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FSM : MonoBehaviour
{
  //update llama al onupdate del estado actual
  // Start de la maquina para inicializar los estados
  public State m_current;
  public State m_Walk;
  public State m_Run;
  public State m_Idle;
  public Rigidbody2D Rigid;
  public void SetState(State newState)
  {
    m_current.OnExit();
    m_current = newState;
    m_current.OnEnter();
  }
  void Start()
  {
    m_Walk = gameObject.AddComponent<Walk>();
    m_Run = gameObject.AddComponent<Run>();
    m_Idle = gameObject.AddComponent<Idle>();
    m_Walk.SetFSM(this);

    m_Run.SetFSM(this);
    m_Idle.SetFSM(this);
    m_current = m_Idle;
    m_current.OnEnter();
    Rigid = GetComponent<Rigidbody2D>();
    //m_Walk.vel
  }
  void Update()
  {
    m_current.OnUpdate();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    m_current.OnCollisionE(collision);
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    m_current.OntriggerS(collision);
  }
  private void OnTriggerExit2D(Collider2D collision)
  {
    m_current.OntriggerEx(collision);
  }
}