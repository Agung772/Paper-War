using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TandaShurikenController : MonoBehaviour
{
    public Animator animator;

    public void Exit()
    {
        Destroy(gameObject, 0.5f);
        animator.SetTrigger("Exit");
    }
}
