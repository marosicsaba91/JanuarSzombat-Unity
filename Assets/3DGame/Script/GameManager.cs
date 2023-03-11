using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject gameOverPanel;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void RestartScen() 
    {
        SceneManager.LoadScene("3dGame");    
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
