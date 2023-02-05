using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum EnemyType
{
  kBasic=0,
  kTurret,
  kFragmenter
}
public enum WaveEventType
{
  kAdd,
  kSetMultiplier
}

[System.Serializable]
public struct WaveEvent
{
  public EnemyType enemy;
  public WaveEventType type;
  public int num;
}

[System.Serializable]
public struct Wave
{
  public List<WaveEvent> waveEvents;
  public float timeBetweenEvents;
}

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

  public float m_timeBetweenWaves;
  public float m_timeBetweenEvents;
  public List<Wave> m_waves;

  Dictionary<EnemyType, float> m_wave = new Dictionary<EnemyType, float>();
  Dictionary<EnemyType, float> m_currentWave = new Dictionary<EnemyType, float>();
  Dictionary<EnemyType, float> m_waveMultiplier = new Dictionary<EnemyType, float>();

  public int m_waveNum = -1;
  public int m_totalEnemiesForSpawn = 0;
  public int m_totalEnemiesForKill = 0;

  public bool m_waveInvoked = false;
  private void Awake()
  {
    m_bc = GetComponent<BoxCollider2D>();
    m_scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
  }

  // Update is called once per frame
  void Update()
  {
    if(GameObject.FindGameObjectWithTag("Enemy") == null && !m_waveInvoked)
    {
      m_waveInvoked = true;
      ++m_waveNum;
      Invoke("executeWave", m_timeBetweenWaves);
    }


    //if (m_currentSpawnTime <= 0 && GameObject.FindGameObjectWithTag("Shroom"))
    //{
    //  
    //}
    //else
    //{
    //  m_currentSpawnTime -= Time.deltaTime;
    //}

    m_scoreText.text = m_currentScore.ToString();
  }

  void executeWave()
  {
    if(m_waveNum< m_waves.Count)
    {
      foreach (var waveEvent in m_waves[m_waveNum].waveEvents)
      {
        if (waveEvent.type == WaveEventType.kAdd)
        {
          m_wave.Add(waveEvent.enemy, waveEvent.num);
          m_waveMultiplier.Add(waveEvent.enemy, 1);
          m_currentWave.Add(waveEvent.enemy, 0);
        }
        else if (waveEvent.type == WaveEventType.kSetMultiplier)
        {
          m_waveMultiplier[waveEvent.enemy] = waveEvent.num;
        }
      }
    }
    
    
    foreach(var waveEvent in m_waveMultiplier)
    {
      m_wave[waveEvent.Key] *= waveEvent.Value;
      m_currentWave[waveEvent.Key] = m_wave[waveEvent.Key];
      m_totalEnemiesForSpawn += Mathf.FloorToInt(m_wave[waveEvent.Key]);
    }
    //for(int i = 0; i< totalEnemies; ++i)
    //{
    //  spawnEnemy();
    //}
    spawnEnemy();
    m_waveInvoked = false;
  }

  void spawnEnemy()
  {
    m_spawnPosition = new Vector2(Random.RandomRange(0, m_bc.size.x) - m_bc.size.x / 2, Random.RandomRange(0, m_bc.size.y) - m_bc.size.y / 2);
    //Debug.Log(m_enemyList.Count.ToString());      
    m_enemyIndex = Random.RandomRange(0, m_enemyList.Count);
    float n;
    while (!m_currentWave.TryGetValue((EnemyType)m_enemyIndex,out n) || m_currentWave[(EnemyType)m_enemyIndex] <= 0)
    {
      m_enemyIndex = Random.RandomRange(0, m_enemyList.Count);
    }
    m_currentWave[(EnemyType)m_enemyIndex] -= 1;
    m_enemyInstance = Instantiate(m_enemyList[m_enemyIndex], m_spawnPosition, Quaternion.identity);
    m_enemyInstance.gameObject.transform.localScale *= m_enemyScale;
    switch (m_enemyIndex)
    {
      case 0:
        m_enemyInstance.GetComponent<Enemy>().m_speed = m_enemySpeed;
        //m_enemyInstance.GetComponent<Steering>().m_maxVel = m_enemySpeed;
        break;
      case 2:
        m_enemyInstance.GetComponent<Steering>().m_maxVel = m_enemySpeed;
        break;
    }
    --m_totalEnemiesForSpawn;
    if (m_totalEnemiesForSpawn > 0)
    {
      if(m_waveNum< m_waves.Count)
      Invoke("spawnEnemy", m_waves[m_waveNum].timeBetweenEvents);
      else
      Invoke("spawnEnemy", m_timeBetweenEvents);
    }
    
    //m_currentSpawnTime = m_spawnTimer;
  }
}
