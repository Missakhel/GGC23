using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  [SerializeField] private GameObject m_botonPausa;
  [SerializeField] private GameObject m_menuPausa;
  private Canvas m_canvas;
  private void Start()
  {
    m_canvas = GetComponent<Canvas>();
    if(m_canvas == null)
    {
      Debug.LogError("Canvas not found");
    }
    m_canvas.enabled = false;
  }
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Time.timeScale = 0f;
      //m_botonPausa.SetActive(false);
      m_canvas.enabled = true;
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
