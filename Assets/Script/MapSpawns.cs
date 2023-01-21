using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawns : MonoBehaviour
{
    public MapManager mapManager;
    int randomInt;
    bool[] randomBool;

    private void Awake()
    {
        mapManager = transform.parent.transform.parent.GetComponent<MapManager>();
        randomBool = new bool[mapManager.maps.Length];
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
            if (mapManager.jumlahMap >= 3)
            {

                Destroy(transform.parent.transform.parent.GetChild(1).gameObject);
            }

                GameObject envi = Instantiate(mapManager.enviroment, transform.parent.transform.parent);
            envi.transform.localPosition = new Vector3(mapManager.positionXEnvi, 0, 0);
            mapManager.positionXEnvi += 70;

            GameManager.instance.Score++;
        }
    }

    void RandomInt()
    {
        int random = Random.Range(0, mapManager.maps.Length);
        for (int i = 0; i < mapManager.maps.Length; i++)
        {
            if (!randomBool[i])
            {
                randomInt = i;
                break;
            }
        }

        if (random == 0 && !randomBool[0]) randomBool[0] = true;
        else if (random == 1 && !randomBool[1]) randomBool[1] = true;
        else if (random == 2 && !randomBool[2]) randomBool[2] = true;
        else if (random == 3 && !randomBool[3]) randomBool[3] = true;
        else if (random == 4 && !randomBool[4]) randomBool[4] = true;
        else RandomInt();
    }
}
