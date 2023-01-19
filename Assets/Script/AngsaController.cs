using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngsaController : MonoBehaviour
{
    public bool angsaParent;
    private void Start()
    {
        if (angsaParent)
        {
            transform.localPosition = new Vector3(0, 0, Random.Range(-3, 3));
            Destroy(gameObject.transform.parent.gameObject, 3.5f);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !angsaParent)
        {
            GameManager.instance.LoseUI();
        }
    }
}
