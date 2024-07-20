using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//copy past:
// |
public class PlayerMovement : MonoBehaviour
{
    public boostStamina boost;

    public float movementSpeed = 3;
    private float playerBoost = 1f;
    private float boostStamina = 100f;

    public float xLimit = 8f;
    public float yLimit = 4.5f;

    private bool playSound;
    private bool soundToggleChange = true;
    AudioSource boostSound;



    void Start()
    {
        boostSound = GetComponent<AudioSource>();
    }

    void Update()
    {

        //move character with velocity of 'speed' + boost with LShift (upgrade with animation + stamina system)
        if (Input.GetKey(KeyCode.LeftShift) && boostStamina > 0)
        {
            playerBoost = 3f;
            boostStamina += -35f * Time.deltaTime;
            boost.SetBoost(boostStamina);
            playSound = true;
            if (playSound && soundToggleChange)
            {
                boostSound.Play();
                soundToggleChange = false;
            }

        }
        else if (boostStamina < 100f)
        {
            playerBoost = 1f;
            boostStamina += 10f * Time.deltaTime;
            boost.SetBoost(boostStamina);
            playSound = false;
            if (!playSound)
            {
                boostSound.Stop();
               if(boostStamina >= 5)
                {
                    soundToggleChange = true;
                }
            }
        }

        print(boostStamina);

        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Vector3 movementVector = new Vector3(xInput, yInput);

        if (movementVector.magnitude > 1)
        {
            movementVector.Normalize();
        }

        transform.position += movementVector * Time.deltaTime * movementSpeed * playerBoost;


        float clampedX = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        float clampedY = Mathf.Clamp(transform.position.y, -yLimit, yLimit);
        transform.position = new Vector3(clampedX, clampedY);

    }
}
