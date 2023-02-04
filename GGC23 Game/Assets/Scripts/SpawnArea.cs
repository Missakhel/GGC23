using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnArea : MonoBehaviour
{
    // Start is called before the first frame update
    int m_currentScore = 0;
    BoxCollider2D m_bc;
    Vector2 m_spawnPosition;
    public GameObject m_enemyPrefab;
    TextMeshProUGUI m_scoreText;
    GameObject m_enemyInstance;

    public float m_timer = 3.0f;
    public float m_enemySpeed = 1.0f;
    float m_currentSpawnTime;
    public float m_enemyScale = 1f;

    private void Awake()
    {
        m_bc = GetComponent<BoxCollider2D>();
        //m_scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_currentSpawnTime <= 0)
        {
            m_currentSpawnTime = m_timer;
            m_spawnPosition = new Vector2(Random.RandomRange(0, m_bc.size.x) - m_bc.size.x / 2, Random.RandomRange(0, m_bc.size.y) - m_bc.size.y / 2);
            m_enemyInstance = Instantiate(m_enemyPrefab, m_spawnPosition, Quaternion.identity);
            m_enemyInstance.GetComponent<Enemy>().speed = m_enemySpeed;
            m_enemyInstance.GetComponent<Enemy>().transform.localScale *= m_enemyScale;
        }
        else
        {
            m_currentSpawnTime -= Time.deltaTime;
        }

        //m_scoreText.text = m_currentScore.ToString();
    }
}
