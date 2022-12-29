using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Mode
    {
        pesawat, kapal
    }

    public Mode modePlayer;
    public new Rigidbody rigidbody;
    public float speedPlayer;
    public float jumpForce;
    public Vector3 movement;
    void Update()
    {
        if (modePlayer == Mode.pesawat)
        {

        }

        //MovePlayer();
        JumpPlayer(false);

        
        if (Input.GetAxis("Vertical") > 0) MovePlayerVelocity("W");
        if (Input.GetAxis("Vertical") < 0) MovePlayerVelocity("S");
        if (Input.GetAxis("Horizontal") > 0) MovePlayerVelocity("D");
        if (Input.GetAxis("Horizontal") < 0) MovePlayerVelocity("A");
        
    }

    void MovePlayerVelocity(string input)
    {
        if (input == "W")
        {
            rigidbody.AddForce(transform.forward * speedPlayer);
        }
        if (input == "A")
        {
            rigidbody.AddForce(-transform.right * speedPlayer);
        }
        if (input == "S")
        {
            rigidbody.AddForce(-transform.forward * speedPlayer);
        }
        if (input == "D")
        {
            rigidbody.AddForce(transform.right * speedPlayer);
        }
    }
    void MovePlayer()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        rigidbody.MovePosition(rigidbody.position + movement * speedPlayer * Time.fixedDeltaTime);
    }

    void JumpPlayer(bool android)
    {
        if (android)
        {
            rigidbody.AddForce(transform.up * jumpForce);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.velocity = Vector3.up * jumpForce;
            }
        }
    }
}
