using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRigibody : MonoBehaviour
{
    public enum Mode
    {
        pesawat, kapal, tamia
    }

    public Mode modePlayer;
    public new Rigidbody rigidbody;
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

            MovePlayer();
            JumpPlayer(false);

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
        verticalInput = Input.GetAxis("Vertical");

        rigidbody.AddForce(Vector3.forward * verticalInput * 50, ForceMode.Force);
        rigidbody.AddForce(Vector3.right * 20, ForceMode.Force);
        
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
                rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            }
        }
    }
}
