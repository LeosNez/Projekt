using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float zataceni = 50f;
    public float akcelerace = 50f;
    public float maxRychlost = 200f;
    public float couvaciRychlost = 20f;


    public float aktualniRychlost = 0f;
    private float moveInput = 0f;
    private float rotateInput = 0f;

    public bool isSpeedBoostActive = false;
    private float speedBoostDuration = 5f;
    public float speedBoostTimer = 0f;
    private float originalMaxSpeed;

    public bool isTurnBoostActive = false;
    private float turnBoostDuration = 5f;
    public float turnBoostTimer = 0f;
    private float originalZataceni;

    public bool isAccBoostActive = false;
    private float accBoostDuration = 5f;
    public float accBoostTimer = 0f;
    private float originalAcc;

    void Update()
    {
        ReadInput();
        HandleMovement();

        if (isSpeedBoostActive)
        {
            speedBoostTimer += Time.deltaTime;
            if (speedBoostTimer >= speedBoostDuration)
            {
                maxRychlost = originalMaxSpeed; 
                isSpeedBoostActive = false;
            }
        }

        if (isTurnBoostActive)
        {
            turnBoostTimer += Time.deltaTime;
            if (turnBoostTimer >= turnBoostDuration)
            {
                zataceni = originalZataceni; 
                isTurnBoostActive = false;
            }
        }

        if (isAccBoostActive)
        {
            accBoostTimer += Time.deltaTime;
            if (accBoostTimer >= accBoostDuration)
            {
                maxRychlost = originalAcc;
                isAccBoostActive = false;
            }
        }
    }

    void ReadInput()
    {
        moveInput = 0f;
        rotateInput = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveInput = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveInput = -1f;
        }

        if (Mathf.Abs(aktualniRychlost) > 1.5)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rotateInput = -1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rotateInput = 1f;
            }
        }
    }

    void HandleMovement()
    {
        if (moveInput >= 0)
        {
            aktualniRychlost += moveInput * akcelerace * Time.deltaTime;
        }
        else
        {
            aktualniRychlost += moveInput * couvaciRychlost * Time.deltaTime;
        }

        aktualniRychlost = Mathf.Clamp(aktualniRychlost, -maxRychlost, maxRychlost); //  Tato funkce se star� o to, �e prvn� hodnota z�stane mezi druhou a t�et� hodnotou kde druh� je min a t�et� je max

        transform.Translate(Vector3.forward * aktualniRychlost * Time.deltaTime); // Star� se o pohyb

        if (Mathf.Abs(moveInput) < 0.1f)
        {
            aktualniRychlost = Mathf.Lerp(aktualniRychlost, 0f, Time.deltaTime); // Postupn� zpomalov�n�. Lerp se star� o plynul� pohyb. prvn� v z�vorce je po��te�n� hodnota, v druh� hodnota na kterou se chceme dostat. Posledn� zaji��uje plynul� pohyb
        }

        float rotation = rotateInput * zataceni * Time.deltaTime; // Nastaven� rotace objektu p�i zat��en�
        transform.Rotate(Vector3.up * rotation); // objekt se bude ot��eet po ose Y na z�klad� rotace
    }

    private void OnCollisionEnter(Collision col)
    {
        moveInput = -moveInput / 3;
        rotateInput = -rotateInput / 3;
        aktualniRychlost = -aktualniRychlost / 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Zpomalen�
        if (other.CompareTag("Kaluz") && !isSpeedBoostActive && !isAccBoostActive)
        {
            // Zaznamenat p�vodn� maxim�ln� rychlost p�ed zpomalen�m
            originalMaxSpeed = maxRychlost;

            isSpeedBoostActive = true;
            maxRychlost = 100f;
            speedBoostTimer = 0f;
        }

        if (other.CompareTag("Zataceni") && !isTurnBoostActive)
        {
            originalZataceni = zataceni;

            isTurnBoostActive = true;
            zataceni = 25f;
            turnBoostTimer = 0f;
        }

        if (other.CompareTag("Zrychleni") && !isAccBoostActive && !isSpeedBoostActive)
        {
            originalAcc = maxRychlost;

            isAccBoostActive = true;
            maxRychlost = 300f;
            accBoostTimer = 0f;
        }
    }
}