using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float zataceni = 100f;
    public float akcelerace = 50f;
    public float maxRychlost = 100f;
    public float couvaciRychlost = 20f;


    public float aktualniRychlost = 0f;
    private float moveInput = 0f;
    private float rotateInput = 0f;

    void Update()
    {
        ReadInput();
        HandleMovement();
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
        moveInput = -moveInput;
        rotateInput = -rotateInput;
        aktualniRychlost = -aktualniRychlost;
    }
}