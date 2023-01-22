using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject enviroment;
    public GameObject[] maps;
    public float jumlahMap, positionXMap, positionXEnvi;
    public int randomInt, randomCheck;
    public bool[] randomBool;

    private void Start()
    {
        randomBool = new bool[maps.Length];
    }
    public void RandomInt()
    {
        randomCheck = 0;
        for (int i = 0; i < maps.Length; i++)
        {
            if (randomBool[i] == true) randomCheck++;
        }
        if (randomCheck == maps.Length) randomBool = new bool[maps.Length];

        randomInt = Random.Range(0, maps.Length);

        if (randomInt == 0 && !randomBool[0]) randomBool[0] = true;
        else if (randomInt == 1 && !randomBool[1]) randomBool[1] = true;
        else if (randomInt == 2 && !randomBool[2]) randomBool[2] = true;
        else if (randomInt == 3 && !randomBool[3]) randomBool[3] = true;
        else if (randomInt == 4 && !randomBool[4]) randomBool[4] = true;
        else RandomInt();


    }
}
