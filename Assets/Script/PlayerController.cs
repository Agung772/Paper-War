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
        VerticalInput(0);
        ChangeMode();
        BatasPlayer();
    }

    void ChangeMode()
    {
        ChangeModeInput(0);

        if (modePlayer == Mode.pesawat)
        {
            pesawat.SetActive(true);
            kapal.SetActive(false);
            tamia.SetActive(false);

            MovePlayer();
            JumpPlayerInput(false);

            if (!groundCheck.groundDarat && !groundCheck.groundAir)
            {
                speedHorizontalPlayer = speedPesawat;
            }
            else
            {
                speedHorizontalPlayer = 0;
            }
        }
        else if (modePlayer == Mode.kapal)
        {
            pesawat.SetActive(false);
            kapal.SetActive(true);
            tamia.SetActive(false);

            MovePlayer();

            if (!groundCheck.groundDarat)
            {
                speedHorizontalPlayer = speedKapal;
            }
            else
            {
                speedHorizontalPlayer = 0;
            }
        }
        else if (modePlayer == Mode.tamia)
        {
            pesawat.SetActive(false);
            kapal.SetActive(false);
            tamia.SetActive(true);

            MovePlayer();

            if (!groundCheck.groundAir)
            {
                speedHorizontalPlayer = speedTamia;
            }
            else
            {
                speedHorizontalPlayer = 0;
            }
        }
    }


    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");


        movement = new Vector3(speedHorizontalPlayer, 0, verticalInput);

        directionY += gravity * Time.deltaTime;
        movement.y = directionY;
        if (groundCheck.groundDarat || groundCheck.groundAir) directionY = 0;


        characterController.Move(movement * speedVerticalPlayer * Time.deltaTime);
    }

    void BatasPlayer()
    {
        if (transform.position.z < -3.5f)
            transform.position = new Vector3(transform.position.x, transform.position.y, -3.5f);
        if (transform.position.z > 3.5f)
            transform.position = new Vector3(transform.position.x, transform.position.y, 3.5f);
        if (transform.position.y > 15)
            transform.position = new Vector3(transform.position.x, 15, transform.position.z);
    }

    public void ChangeModeInput(int mode)
    {
        if (mode == 1)
        {
            modePlayer = Mode.pesawat;
        }
        else if (mode == 2)
        {
            modePlayer = Mode.kapal;
        }
        else if (mode == 3)
        {
            modePlayer = Mode.tamia;
        }
        else if (mode == 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) modePlayer = Mode.pesawat;
            if (Input.GetKeyDown(KeyCode.Alpha2)) modePlayer = Mode.kapal;
            if (Input.GetKeyDown(KeyCode.Alpha3)) modePlayer = Mode.tamia;
        }
    }
    public void JumpPlayerInput(bool android)
    {
        if (android)
        {
            if (modePlayer == Mode.pesawat)
            {
                directionY = jumpForce;
                groundCheck.groundDarat = false;
                groundCheck.groundAir = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                directionY = jumpForce;
                groundCheck.groundDarat = false;
                groundCheck.groundAir = false;
            }
        }
    }

    public void VerticalInput(int condition)
    {
        if (condition == 0 && Input.GetAxis("Vertical") == 0) verticalInput = 0;
        else if (condition == 1) verticalInput = -1;
        else if (condition == 2) verticalInput = 1;

        
    }
}
