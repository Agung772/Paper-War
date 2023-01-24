using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneStart : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject gameplayUI;

    private void Awake()
    {
        gameplayUI.SetActive(false);
    }
    private void Update()
    {
        if (playableDirector.time.ToString("F1") == playableDirector.duration.ToString("F1"))
        {
            gameplayUI.SetActive(true);
            Destroy(gameObject);
            print("Selesai");
        }
    }
}
