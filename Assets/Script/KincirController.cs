using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KincirController : MonoBehaviour
{
    public PlayerController playerController;
    public float nerf;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController>();
            playerController.nerfSpeed = nerf;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.nerfSpeed = 1;
        }
    }
}
