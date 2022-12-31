using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Mode
    {
        pesawat, kapal, tamia
    }

    public Mode modePlayer;
    public CharacterController characterController;
    public GroundCheck groundCheck;
    public GameObject pesawat, kapal, tamia;

    public float speedPesawat, speedKapal, speedTamia;
    public float speedVerticalPlayer, speedHorizontalPlayer;
    public float jumpForce, gravity = -9.81f;


    public Vector3 movement;
    public float horizontalInput, verticalInput, directionY;

    void Update()
    {
        ChangeMode();
    }

    void ChangeMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) modePlayer = Mode.pesawat;
        if (Input.GetKeyDown(KeyCode.Alpha2)) modePlayer = Mode.kapal;
        if (Input.GetKeyDown(KeyCode.Alpha3)) modePlayer = Mode.tamia;

        if (modePlayer == Mode.pesawat)
        {
            pesawat.SetActive(true);
            kapal.SetActive(false);
            tamia.SetActive(false);


            speedHorizontalPlayer = speedPesawat;
            MovePlayer();
            JumpPlayer(false);
        }
        else if (modePlayer == Mode.kapal)
        {
            pesawat.SetActive(false);
            kapal.SetActive(true);
            tamia.SetActive(false);


            speedHorizontalPlayer = speedKapal;
            MovePlayer();
        }
        else if (modePlayer == Mode.tamia)
        {
            pesawat.SetActive(false);
            kapal.SetActive(false);
            tamia.SetActive(true);


            speedHorizontalPlayer = speedTamia;
            MovePlayer();
        }
    }


    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movement = new Vector3(speedHorizontalPlayer, 0, verticalInput);

        directionY += gravity * Time.deltaTime;
        movement.y = directionY;
        if (groundCheck.ground) directionY = 0;


        characterController.Move(movement * speedVerticalPlayer * Time.deltaTime);
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
