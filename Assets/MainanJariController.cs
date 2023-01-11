using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainanJariController : MonoBehaviour
{
    public float speed, x;
    public Transform target;

    private void Start()
    {
        x = transform.position.x;
    }

    private void Update()
    {
        x += speed * Time.deltaTime;
        //transform.position = new Vector3(x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
