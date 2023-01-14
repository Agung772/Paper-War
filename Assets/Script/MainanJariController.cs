using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainanJariController : MonoBehaviour
{
    public float speed, akselerasi;
    public Transform target;



    private void Start()
    {

    }

    private void Update()
    {
        Akselerasi();
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * akselerasi * Time.deltaTime);

    }

    void Akselerasi()
    {
        akselerasi += Time.deltaTime / 7;
        akselerasi = Mathf.Clamp(akselerasi, 0, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.LoseUI();
            
        }
    }
}
