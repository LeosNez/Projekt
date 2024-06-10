using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skokanek : MonoBehaviour
{
    public float jumpForce = 10f; // S�la skoku
    public float jumpDistance = 5f; // Vzd�lenost, kterou auto ulet� po skoku

    private bool isOnSlope = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slope")) // Pokud naraz� na naklon�nou plochu
        {
            isOnSlope = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slope")) // Pokud opust� naklon�nou plochu
        {
            isOnSlope = false;
            Jump(); // Prov�d� skok, proto�e auto opustilo rampu
        }
    }

    void Jump()
    {
        if (isOnSlope) return; // Pokud je je�t� auto na ramp�, neprove�te skok
        Rigidbody rb = GetComponent<Rigidbody>(); // P��stup k Rigidbody vozidla
        rb.AddForce(transform.forward * jumpDistance, ForceMode.Impulse); // Aplikace s�ly sm�rem vp�ed pro let po skoku. ForceMode.Impulse zajist�, �e se ptovede hned
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Aplikace s�ly sm�rem nahoru pro skok
    }
}
