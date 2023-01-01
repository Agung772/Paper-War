using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawns : MonoBehaviour
{
    public MapManager mapManager;

    private void Awake()
    {
        mapManager = transform.parent.transform.parent.GetComponent<MapManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject map = Instantiate(mapManager.maps[Random.Range(0, mapManager.maps.Length)], transform.parent.transform.parent);
            map.transform.localPosition = new Vector3(mapManager.positionXMap + Random.Range(110, 120) , Random.Range(0, 3), 0);
            mapManager.positionXMap += 70;
            mapManager.jumlahMap++;

            if (mapManager.jumlahMap >= 2)
            {
                Destroy(transform.parent.transform.parent.GetChild(0).gameObject);
            }

        }
    }
}
