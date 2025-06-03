using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreCoin : MonoBehaviour
{
 public float RotateSpeed;

    public ParticleSystem particle;
    
    void Update()
    {
        if(GameManager.instance.isPause == false)
        {
            transform.Rotate(RotateSpeed, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.playerScore += 100;
            Debug.Log(GameManager.instance.playerScore);

            GameObject.Instantiate(particle,transform.position,transform.rotation);

            gameObject.SetActive(false);
        }
    }
}