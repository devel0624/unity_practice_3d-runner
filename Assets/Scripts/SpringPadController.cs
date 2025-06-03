using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPad : MonoBehaviour
{
    public float springPower = 5f;
    public float pushPower = 300f;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {


                Vector3 velocity = playerRb.velocity;
                playerRb.velocity = velocity;
                playerRb.AddForce(Vector3.up * springPower, ForceMode.Impulse);
                playerRb.AddForce(transform.forward * pushPower, ForceMode.Impulse);

            }
        }
    }

}
