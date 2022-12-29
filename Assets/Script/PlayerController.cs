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
    public CharacterController characterController;
    public GroundCheck groundCheck;

    public float speedPlayer;
    public float jumpForce, gravity = -9.81f;


    public Vector3 movement;
    public float horizontalInput, verticalInput, directionY;

    void Update()
    {
        if (modePlayer == Mode.pesawat)
        {

        }

        MovePlayer();
        JumpPlayer(false);


    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movement = new Vector3(horizontalInput, 0, verticalInput);

        directionY += gravity * Time.deltaTime;
        movement.y = directionY;
        if (groundCheck.ground) directionY = 0;


        characterController.Move(movement * speedPlayer * Time.deltaTime);
    }

    void JumpPlayer(bool android)
    {
        if (android)
        {

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                directionY = jumpForce;
                groundCheck.ground = false;
            }
        }
    }
}
