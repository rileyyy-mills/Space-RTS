using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitNew : MonoBehaviour
{
    public float xSpread;
    public float zSpread;
    public float yOffset;
    public Transform centerPoint;

    public float rotSpeed;
    public bool rotateClockwise = true;

    float timer = 0;
    float x;
    Vector3 previousPosition;
    Quaternion initialRotation;
    
    void Start(){
        previousPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        timer += Time.deltaTime * rotSpeed;
        Rotate();
    }

    void Rotate(){

        if (rotateClockwise) {
            x = -Mathf.Cos(timer) * xSpread;
        }
        else {
            x = Mathf.Cos(timer) * xSpread;
        }

        float z = Mathf.Sin(timer) * zSpread;
        Vector3 pos = new Vector3(x, yOffset, z);
        transform.position = pos + centerPoint.position;

        // Calculate forward direction based on velocity
        Vector3 currentVelocity = (transform.position - previousPosition) / Time.deltaTime;
        if (currentVelocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(currentVelocity.normalized, Vector3.up) * initialRotation; // Apply rotation offset
        }

        previousPosition = transform.position;
    
    }
}
