using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBlock : MonoBehaviour
{

    public ParticleSystem particle;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            particle.Play();

            GameManager.instance.GameClear();
        }
    }
}
