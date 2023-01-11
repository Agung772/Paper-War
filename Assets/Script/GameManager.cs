using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loseUI;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        instance = this;
    }

    public void LoseUI()
    {
        PlayerController.instance.FalseMesh();
        loseUI.SetActive(true);
        Time.timeScale = 0.5f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
