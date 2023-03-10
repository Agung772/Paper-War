using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loseUI;

    public Button[] modeButton;
    public Image[] cooldownImage;

    public Button jumpButton;
    public Image jumpImage;

    public Image energyPesawatImage;

    public int score;
    public int Score
    {
        get { return score; }
        set { score = value; scoreText.text = "Score : " + score; }
    }
    public Text scoreText, fpsText;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        instance = this;

    }

    public void LoseUI()
    {
        PlayerController.instance.FalseMesh();
        PlayerController.instance.playerOperation = false;
        loseUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void CooldownImage(float value)
    {
        cooldownImage[0].fillAmount = value;
        cooldownImage[1].fillAmount = value;
        cooldownImage[2].fillAmount = value;

        if (value > 0)
        {
            modeButton[0].interactable = false;
            modeButton[1].interactable = false;
            modeButton[2].interactable = false;
        }
        else
        {
            modeButton[0].interactable = true;
            modeButton[1].interactable = true;
            modeButton[2].interactable = true;
        }
    }

    public void CloseJumpUI(bool condition)
    {
        if (condition == true)
        {
            jumpButton.interactable = false;
            jumpImage.gameObject.SetActive(true);
        }
        else
        {
            jumpButton.interactable = true;
            jumpImage.gameObject.SetActive(false);
        }
    }

    public void EnergyPesawatUI(float value)
    {
        energyPesawatImage.fillAmount = value;
    }

    public void Fps(float value)
    {
        fpsText.text = value.ToString("F0");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
