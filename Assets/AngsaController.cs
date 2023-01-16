using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngsaController : MonoBehaviour
{
    public bool move;
    public float speedMove, speedSpawn;
    public Transform angsaTransform;
    public new Rigidbody rigidbody;
    public Animator animator;
    private void Start()
    {
        angsaTransform.localPosition = new Vector3 (angsaTransform.localPosition.x, -3, angsaTransform.localPosition.z);
    }

    private void Update()
    {
        Invoke("Move", 1);
    }

    void Move()
    {
        if (!move)
        {
            angsaTransform.localPosition = Vector3.MoveTowards(angsaTransform.localPosition, new Vector3(angsaTransform.localPosition.x, 0, angsaTransform.localPosition.z), speedSpawn * Time.deltaTime);

            if (angsaTransform.localPosition.y == 0) 
            { 
                move = true;
                animator.SetTrigger("Exit");
            
            }
        }
        else
        {
            rigidbody.AddForce(Vector3.left * speedMove * 100 * Time.deltaTime);
        }
        
    }
}
