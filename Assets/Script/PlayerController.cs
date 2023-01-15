using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public enum Mode
    {
        pesawat, kapal, tamia
    }

    public Mode modePlayer;
    public CharacterController characterController;
    public GroundCheck groundCheck;
    public GameObject pesawat, kapal, tamia;
    public ParticleSystem changeModeVfx;


    public float speedPesawat, speedKapal, speedTamia;
    public float speedVerticalPlayer, speedHorizontalPlayer, akselerasi, nerfSpeed = 1;
    public float jumpForce, gravity = -9.81f;


    public Vector3 movement;
    public float horizontalInput, verticalInput, directionY;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        Akselerasi();
        ChangeMode();
        BatasPlayer();

    }

    void ChangeMode()
    {
        ChangeModeInput(0);

        if (modePlayer == Mode.pesawat)
        {
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

        verticalInput = SimpleInput.GetAxis("Vertical");
      

        movement = new Vector3(speedHorizontalPlayer * akselerasi * nerfSpeed, 0, verticalInput);

        directionY += gravity * Time.deltaTime;
        movement.y = directionY;
        if (groundCheck.groundDarat || groundCheck.groundAir) directionY = 0;


        characterController.Move(movement * speedVerticalPlayer * Time.deltaTime);
    }

    void Akselerasi()
    {
        akselerasi += Time.deltaTime / 5;
        akselerasi = Mathf.Clamp(akselerasi, 0, 1);
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

    void ModeInput(string mode)
    {
        if (mode == "pesawat")
        {
            modePlayer = Mode.pesawat;
            pesawat.SetActive(true);
            kapal.SetActive(false);
            tamia.SetActive(false);
        }
        else if (mode == "kapal")
        {
            modePlayer = Mode.kapal;
            pesawat.SetActive(false);
            kapal.SetActive(true);
            tamia.SetActive(false);
        }
        else if (mode == "tamia")
        {
            modePlayer = Mode.tamia;
            pesawat.SetActive(false);
            kapal.SetActive(false);
            tamia.SetActive(true);
        }
    }

    int conditionsCM;
    public void ChangeModeInput(int mode)
    {
        if (mode == 1 && conditionsCM != 1)
        {
            conditionsCM = 1;
            ModeInput("pesawat");
            changeModeVfx.Play();
        }
        else if (mode == 2 && conditionsCM != 2)
        {
            conditionsCM = 2;
            ModeInput("kapal");
            changeModeVfx.Play();
        }
        else if (mode == 3 && conditionsCM != 3)
        {
            conditionsCM = 3;
            ModeInput("tamia");
            changeModeVfx.Play();
        }
        else if (mode == 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && conditionsCM != 1)
            {
                conditionsCM = 1;
                ModeInput("pesawat");
                changeModeVfx.Play();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && conditionsCM != 2)
            {
                conditionsCM = 2;
                ModeInput("kapal");
                changeModeVfx.Play();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && conditionsCM != 3) 
            {
                conditionsCM = 3;
                ModeInput("tamia");
                changeModeVfx.Play();
            }
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

    public void FalseMesh()
    {
        changeModeVfx.Play();
        pesawat.SetActive(false);
        kapal.SetActive(false);
        tamia.SetActive(false);
        nerfSpeed = 0;
    }

}
