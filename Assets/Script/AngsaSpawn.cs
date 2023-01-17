using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngsaSpawn : MonoBehaviour
{
    public GameObject angsaPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(angsaPrefab, transform);
        }

    }
}
