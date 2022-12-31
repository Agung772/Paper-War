using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawns : MonoBehaviour
{
    public GameObject[] maps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject map = Instantiate(maps[Random.Range(0, maps.Length)], transform.parent.transform.parent);
            map.transform.localPosition = new Vector3(transform.parent.localPosition.x + Random.Range(110, 120) , Random.Range(0, 3), 0);
        }
    }
}
