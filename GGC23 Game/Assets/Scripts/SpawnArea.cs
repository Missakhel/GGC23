using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D m_bc;
    Vector2 m_spawnPosition;
    public GameObject m_enemyPrefab;
    public float m_timer = 3.0f;
    float m_currentSpawnTime;

    private void Awake()
    {
        m_bc = GetComponent<BoxCollider2D>();

        //m_spawnPosition = Random.Range(m_bc.size)
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_currentSpawnTime <= 0)
        {
            m_currentSpawnTime -= Time.deltaTime;
            Instantiate
        }
        else
        {
            m_currentSpawnTime = m_timer;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, m_bc.size);
        Gizmos.color = Color.magenta;
    }
}
