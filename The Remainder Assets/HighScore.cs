using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{
  public TextMeshProUGUI m_text;
  // Start is called before the first frame update
  void Start()
  {
    m_text.text = "High score: " + PlayerPrefs.GetInt("high score",0);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
