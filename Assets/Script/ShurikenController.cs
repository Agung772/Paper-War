using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public new ParticleSystem particleSystem;
    public TrailRenderer trailRenderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundDarat") || other.CompareTag("GroundAir"))
        {
            rigidbody.isKinematic = true;
            trailRenderer.enabled = false;
            StartCoroutine(Getaran());
        }

        if (other.CompareTag("Player"))
        {
            GameManager.instance.LoseUI();

            Destroy(gameObject);
            particleSystem.Play();
            Destroy(particleSystem.gameObject, 1.5f);
            particleSystem.transform.parent = null;
        }
    }

    public float durasiGeter;
    IEnumerator Getaran()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime <= durasiGeter)
        {
            elapsedTime += Time.deltaTime;
            float strength = elapsedTime * 0.2f;
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        if (elapsedTime >= 1)
        {
            Destroy(gameObject);
            particleSystem.Play();
            Destroy(particleSystem.gameObject, 1.5f);
            particleSystem.transform.parent = null;
        }
        transform.position = startPosition;
    }
}
