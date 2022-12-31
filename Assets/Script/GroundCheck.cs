using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool groundDarat, groundAir;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundDarat"))
        {
            groundDarat = true;
        }
        if (other.CompareTag("GroundAir"))
        {
            groundAir = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GroundDarat"))
        {
            groundDarat = false;
        }
        if (other.CompareTag("GroundAir"))
        {
            groundAir = false;
        }
    }
}
