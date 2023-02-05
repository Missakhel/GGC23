using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform m_target;
    public float m_smoothness = 5.0f;
    Vector3 m_cameraPos;
    public Vector3 m_bounceAmount;
    public float m_maxOffMagnitude;
    //Shake Vars
    public int m_shakeCycles = 1;
    public float m_shakeMultiplier;
    public float m_shakeDuration = 0.5f;
    public bool m_zoom = false;
    float m_shakeTimeCounter = 0.0f;
    [HideInInspector] public bool m_isShaking = false;
    Vector3 m_currentOffset;

    // Update is called once per frame
    void Update()
    {
        Stun();
    }

    public void StartStun(float multiplier)
    {
        m_isShaking = true;
        m_shakeMultiplier = multiplier;
        m_shakeTimeCounter = 0.0f;
    }

    private void Stun()
    {
        transform.position -= m_currentOffset;
        if (m_isShaking)
        {
            m_shakeTimeCounter += Time.deltaTime;
            m_currentOffset = Mathf.Sin(m_shakeTimeCounter / m_shakeDuration * Mathf.PI * 2 * m_shakeCycles) * (m_bounceAmount * m_shakeMultiplier);
            if (m_shakeTimeCounter >= m_shakeDuration)
            {
                m_isShaking = false;
                m_currentOffset = Vector3.zero;
            }
        }
        transform.position += m_currentOffset;
    }
}
