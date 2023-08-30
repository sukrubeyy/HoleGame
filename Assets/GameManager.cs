using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int ObstacleCount;
    void Start()
    {
        ObstacleCount = FindObjectsOfType<ObstacleDestroyer>().Length;
    }

    private void Update()
    {
        if (ObstacleCount <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
