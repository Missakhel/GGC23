using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnArea : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public int m_currentScore = 0;
    BoxCollider2D m_bc;
    Vector2 m_spawnPosition;
  public List<GameObject> m_enemyList = new List<GameObject>();
  //public GameObject m_enemyPrefab;
  int m_enemyIndex;
    TextMeshProUGUI m_scoreText;
    GameObject m_enemyInstance;

    public float m_spawnTimer = 10.0f; //Counts the time it will take the enemy to spawn again;
    public float m_enemySpeed = .1f;
    float m_currentSpawnTime;
    public float m_enemyScale = 1f;

    private void Awake()
    {
        m_bc = GetComponent<BoxCollider2D>();
        m_scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_currentSpawnTime <= 0 && GameObject.FindGameObjectWithTag("Shroom"))
        {
            m_spawnPosition = new Vector2(Random.RandomRange(0, m_bc.size.x) - m_bc.size.x / 2, Random.RandomRange(0, m_bc.size.y) - m_bc.size.y / 2);
      //Debug.Log(m_enemyList.Count.ToString());      
      m_enemyIndex = Random.RandomRange(0, m_enemyList.Count);
            m_enemyInstance = Instantiate(m_enemyList[m_enemyIndex], m_spawnPosition, Quaternion.identity);
            m_enemyInstance.gameObject.transform.localScale *= m_enemyScale;
            switch (m_enemyIndex)
            {
              case 0:
                m_enemyInstance.GetComponent<Enemy>().m_speed = m_enemySpeed;
                break;
              case 2:
                m_enemyInstance.GetComponent<Steering>().m_maxVel = m_enemySpeed;
              break;
      }
            
            m_currentSpawnTime = m_spawnTimer;
        }
        else
        {
            m_currentSpawnTime -= Time.deltaTime;
        }

        m_scoreText.text = m_currentScore.ToString();
    }
}
