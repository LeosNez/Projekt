using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olej : MonoBehaviour
{
    public float RotationDuration = 10f;
    public bool IsRotating = false;

    private ChangeColor cC;

    void Start()
    {
        cC = GetComponent<ChangeColor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Olejik") && !IsRotating)
        {
            StartCoroutine(RotateAroundY(2, RotationDuration));  // Spust� oto�en� dvakr�t kolem osy Y
        }
    }

    private IEnumerator RotateAroundY(int rotations, float duration)
    {
        IsRotating = true;
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

        IsRotating = false;
        cC.CaraO1.SetActive(false);
        cC.CaraO2.SetActive(false);
    }
}