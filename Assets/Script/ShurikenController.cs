using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public new ParticleSystem particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundDarat") || other.CompareTag("GroundAir") || other.CompareTag("Player"))
        {
            rigidbody.isKinematic = true;
            particleSystem.transform.parent = null;
            particleSystem.Play();

            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            GameManager.instance.LoseUI();
        }

    }
}
