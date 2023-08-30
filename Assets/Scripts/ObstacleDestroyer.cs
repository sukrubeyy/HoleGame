using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
  
    private void Update()
    {
        if (transform.position.y < -5f)
        {
            GameManager.ObstacleCount--;
            Destroy(this.gameObject);
        }
    }
}
