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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
