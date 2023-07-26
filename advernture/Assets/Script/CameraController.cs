using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Joystick joystick;
    public float rotationSpeed = 5f;

    public void Update()
    {
        float verticalInput = joystick.Vertical;

        // Yukar� y�nde joystick hareketi yap�l�rsa
        if (verticalInput > 0)
        {
            float rotationAmount = verticalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(-rotationAmount, 0f, 0f);
        }
        // A�a�� y�nde joystick hareketi yap�l�rsa
        else if (verticalInput < 0)
        {
            float rotationAmount = Mathf.Abs(verticalInput) * rotationSpeed * Time.deltaTime;
            transform.Rotate(rotationAmount, 0f, 0f);
        }
    }
}
