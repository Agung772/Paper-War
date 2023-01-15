using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawns : MonoBehaviour
{
    public GameObject shurikenPrefab, tandaShurikenPrefab;
    public float speedForce, speedSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                Spawns();
                yield return new WaitForSeconds(speedSpawn);
                Spawns();
                yield return new WaitForSeconds(speedSpawn);
                Spawns();
                yield return new WaitForSeconds(speedSpawn);
                Spawns();
                yield return new WaitForSeconds(speedSpawn);
            }
        }
    }

    void Spawns()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            GameObject shurikenObject = Instantiate(shurikenPrefab, transform);
            shurikenObject.transform.position = new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y, transform.position.z + Random.Range(-5, 5));
            shurikenObject.GetComponent<MeshRenderer>().enabled = false;

            GameObject tandaObject = Instantiate(tandaShurikenPrefab, transform);
            tandaObject.transform.position = shurikenObject.transform.position + new Vector3(0, 0, 0);

            yield return new WaitForSeconds(0.7f);

            shurikenObject.GetComponent<Rigidbody>().AddForce(transform.forward * speedForce, ForceMode.Impulse);
            float randomSpeed = speedForce + Random.Range(-20, 20);
            print(randomSpeed);
            shurikenObject.GetComponent<Rigidbody>().angularVelocity = Vector3.forward * randomSpeed;
            shurikenObject.GetComponent<MeshRenderer>().enabled = true;

            Destroy(shurikenObject, 3);
            Destroy(tandaObject, 1);
        }

    }
}
