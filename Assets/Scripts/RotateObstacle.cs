using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{

    public float ObstacleRotateSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        if(GameManager.instance.isPause == false)
        {
            transform.Rotate(0, ObstacleRotateSpeed, 0);
        }
    }
}