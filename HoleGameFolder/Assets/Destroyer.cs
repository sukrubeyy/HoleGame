using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Temas Var YOK OL");
       // Destroy(other.gameObject);
    }
}
