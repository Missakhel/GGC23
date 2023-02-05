using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State
{
  public Vector2 m_dir = new Vector2(0,1);
  [SerializeField] public float m_vel = 6f;
  // Start is called before the first frame update
  public override void OnEnter()
  {

  }

  // Update is called once per frame
  public override void OnUpdate()
  {
    Vector2 movement = new Vector2(0, 0);
    if (Input.GetKey(KeyCode.A))
    {
      movement += new Vector2(-1, 0);
    }
    if (Input.GetKey(KeyCode.D))
    {
      movement += new Vector2(1, 0);
    }
    if (Input.GetKey(KeyCode.W))
    {
      movement += new Vector2(0, 1);
    }
    if (Input.GetKey(KeyCode.S))
    {
      movement += new Vector2(0, -1);
    }
    movement.Normalize();
    //float m_moveX = Input.GetAxisRaw("Horizontal");
    //float m_moveY = Input.GetAxisRaw("Vertical");
    //var newDir = new Vector2(m_moveX, m_moveY).normalized;
    var vel = movement * m_vel * Time.deltaTime;
    transform.position += new Vector3(vel.x, vel.y, 0);
    if (Input.GetKey(KeyCode.LeftShift))
    {
      m_statemachine.SetState(m_statemachine.m_Run);
    }
    if (movement == Vector2.zero)
    {
      m_statemachine.SetState(m_statemachine.m_Idle);
    }
    else
    {
      m_dir = movement;
    }
  }
  public override void OnExit()
  {

  }
}
