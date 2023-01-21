using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KipasController : MonoBehaviour
{
    public Animator animator;

    IEnumerator Start()
    {
        animator.enabled = false;
        yield return new WaitForSeconds(Random.Range(0, 6));
        animator.enabled = true;
    }
}
