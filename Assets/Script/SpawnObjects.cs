using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject prefab;
    public float speedForce;

    private void Start()
    {
        InvokeRepeating("Spawns", 0, 2);

    }

    void Spawns()
    {
        GameObject objectSpawn = Instantiate(prefab, transform.position + new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0), transform.rotation);
        objectSpawn.GetComponent<Rigidbody>().AddForce(Vector3.back * speedForce, ForceMode.Impulse);
        Destroy(objectSpawn, 10);
    }
}
