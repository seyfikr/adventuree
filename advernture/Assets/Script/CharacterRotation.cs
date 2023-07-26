using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterRotation : MonoBehaviour
{
    
    public GameObject character;
    private float rotationSpeed = 8.5f;

   
    void Update()
    {
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float touchDeltaX = touch.deltaPosition.x;
                float rotationAmount = touchDeltaX * rotationSpeed * Time.deltaTime;
                character.transform.Rotate(0f, rotationAmount, 0f);
                
            }
        }
    }
}
    
