using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Joystick joystick;
    public float rotationSpeed = 15f;


    public void Update()
    {
        float verticalInput = joystick.Vertical;

        if (verticalInput > 0)
        {
            float rotationAmount = verticalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(-rotationAmount, 0f, 0f);
        }
        
        else if (verticalInput < 0)
        {
            float rotationAmount = Mathf.Abs(verticalInput) * rotationSpeed * Time.deltaTime;
            transform.Rotate(rotationAmount, 0f, 0f);
        }
    }
}
