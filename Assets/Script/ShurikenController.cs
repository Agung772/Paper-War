using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    public new Rigidbody rigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundDarat") || other.CompareTag("GroundAir") || other.CompareTag("Player"))
        {
            rigidbody.isKinematic = true;
        }

    }
}
