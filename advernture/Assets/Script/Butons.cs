using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butons : MonoBehaviour
{
    public GameObject stopPanel;
    public void StopPanel()
    {
        stopPanel.SetActive(true);
        Time.timeScale=0;
    }
    public void ClosePanel()
    {
        stopPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
