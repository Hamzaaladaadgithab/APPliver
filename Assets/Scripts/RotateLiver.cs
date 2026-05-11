using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RotateLiver : MonoBehaviour
{
   
    public float rotationSpeed = 25f;

    void Update()
    {
        
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}