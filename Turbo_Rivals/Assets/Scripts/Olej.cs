using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olej : MonoBehaviour
{
    public float rotationDuration = 10f;
    private bool isRotating = false;

    private ChangeColor cC;

    void Start()
    {
        cC = GetComponent<ChangeColor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Olejik") && !isRotating)
        {
            StartCoroutine(RotateAroundY(2, rotationDuration));  // Spust� oto�en� dvakr�t kolem osy Y
        }
    }

    private IEnumerator RotateAroundY(int rotations, float duration)
    {
        isRotating = true;
        float totalRotation = 180 * rotations;  // Celkov� �hel oto�en�
        float rotationSpeed = totalRotation / duration;  // Rychlost oto�en� (stupn� za sekundu)

        float rotated = 0f;
        while (rotated < totalRotation)
        {
            float step = rotationSpeed * Time.deltaTime;  // V�po�et oto�en� v aktu�ln�m frameu
            transform.Rotate(0, step, 0);  // Oto�en� kolem osy Y
            rotated += step;
            yield return null;  // �ek� do dal��ho framu
        }

        isRotating = false;
        cC.caraO1.SetActive(false);
        cC.caraO2.SetActive(false);
    }
}