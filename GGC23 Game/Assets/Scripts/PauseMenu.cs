using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  [SerializeField] private GameObject m_botonPausa;
  [SerializeField] private GameObject m_menuPausa;
  private GameObject m_canvas;
  private void Awake()
  {
    m_canvas = GameObject.Find("Pause");
    m_canvas.SetActive(false);
  }
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Time.timeScale = 0f;
      //m_botonPausa.SetActive(false);
      m_canvas.SetActive(true);
    }
  }
  public void Reanudar()
  {
    Time.timeScale = 1.0f;
   // m_botonPausa.SetActive(true);
    m_menuPausa.SetActive(false);
  }
  public void returnMainMenu()
  {
    Time.timeScale = 1.0f;
    SceneManager.LoadScene("MenuInicial");
  }
}
