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
    public float energyPesawat;
    public float speedVerticalPlayer, speedHorizontalPlayer, akselerasi, nerfSpeed = 1;
    public float jumpForce, gravity = -9.81f;


    public Vector3 movement;
    public float horizontalInput, verticalInput, directionY, cooldownMode;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeModeInput("tamia");
    }
    void Update()
    {
        Akselerasi();
        ChangeMode();
        BatasPlayer();
        CooldownMode();
        EnergyPesawat();
    }

    void ChangeMode()
    {
        ChangeModeInput("pc");

        if (modePlayer == Mode.pesawat)
        {
            MovePlayer();
            JumpPlayerInput(false);


            if (energyPesawat == 0) ChangeModeInput("tamia");

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

    void EnergyPesawat()
    {
        if (modePlayer == Mode.pesawat) energyPesawat -= Time.deltaTime / 5;
        else energyPesawat += Time.deltaTime / 3;

        energyPesawat = Mathf.Clamp(energyPesawat, 0, 1);
        GameManager.instance.EnergyPesawatUI(energyPesawat);
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

    void CooldownMode()
    {
        cooldownMode -= Time.deltaTime;
        cooldownMode = Mathf.Clamp(cooldownMode, 0, 1);

        GameManager.instance.CooldownImage(cooldownMode);
    }

    void ModeInput(string mode)
    {
        cooldownMode = 1;

        if (mode == "pesawat")
        {
            modePlayer = Mode.pesawat;
            pesawat.SetActive(true);
            kapal.SetActive(false);
            tamia.SetActive(false);

            GameManager.instance.CloseJumpUI(false);
        }
        else if (mode == "kapal")
        {
            modePlayer = Mode.kapal;
            pesawat.SetActive(false);
            kapal.SetActive(true);
            tamia.SetActive(false);

            GameManager.instance.CloseJumpUI(true);
        }
        else if (mode == "tamia")
        {
            modePlayer = Mode.tamia;
            pesawat.SetActive(false);
            kapal.SetActive(false);
            tamia.SetActive(true);

            GameManager.instance.CloseJumpUI(true);
        }

        changeModeVfx.Play();
    }

    int conditionsCM;
    public void ChangeModeInput(string mode)
    {
        if (cooldownMode > 0) return;

        if (mode == "pesawat" && conditionsCM != 1)
        {
            conditionsCM = 1;
            ModeInput("pesawat");
        }
        else if (mode == "kapal" && conditionsCM != 2)
        {
            conditionsCM = 2;
            ModeInput("kapal");
        }
        else if (mode == "tamia" && conditionsCM != 3)
        {
            conditionsCM = 3;
            ModeInput("tamia");
        }
        else if (mode == "pc")
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && conditionsCM != 1)
            {
                conditionsCM = 1;
                ModeInput("pesawat");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && conditionsCM != 2)
            {
                conditionsCM = 2;
                ModeInput("kapal");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && conditionsCM != 3) 
            {
                conditionsCM = 3;
                ModeInput("tamia");
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
