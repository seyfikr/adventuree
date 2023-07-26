using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public float hiz = 3f;
    private bool isButtonForward = false;
    private bool isButtonBack = false;
    private bool isButtonRight = false;
    private bool isButtonLeft = false;
    public GameObject charecter;
    private float rotationSpeed = 8.5f;

    private void Update()

    {
        GameObject targetObject = GameObject.Find("character");
        Animator anim = targetObject.GetComponent<Animator>();
        if (isButtonForward)
        {
            float forward = hiz * Time.deltaTime;
            charecter.transform.Translate(0, 0, forward);
        }
        if (isButtonBack)
        {
            float back = hiz * Time.deltaTime;
            charecter.transform.Translate(0, 0, -back);
        }
        if (isButtonRight)
        {
            float right = hiz * Time.deltaTime;
            charecter.transform.Translate(right, 0, 0);
        }
        if (isButtonLeft)
        {
            float left = hiz * Time.deltaTime;
            charecter.transform.Translate(-left, 0, 0);
        }
    }

    public void ForwardPress()
    {
        isButtonForward = true;
        anim.SetBool("walk", true);
        ÝsRotation();

    }
    public void ForwardRelease()
    {
        isButtonForward = false;
        anim.SetBool("walk", false);
        
    }
    public void BackPress()
    {
        isButtonBack = true;
        anim.SetBool("walk", true);
        ÝsRotation();
    }
    public void BackRelease()
    {
        isButtonBack = false;
        anim.SetBool("walk", false);
        
    }
    public void rightPress()
    {
        isButtonRight = true;
        anim.SetBool("walk", true);
        ÝsRotation();
    }
    public void rightRelease()
    {
        isButtonRight = false;
        anim.SetBool("walk", false);
        
    }
    public void leftPress()
    {
        isButtonLeft = true;
        anim.SetBool("walk", true);
        ÝsRotation();
    }
    public void leftRelease()
    {
        isButtonLeft = false;
        anim.SetBool("walk", false);
        
    }
    public void ÝsRotation()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float touchDeltaX = touch.deltaPosition.x;
                float rotationAmount = touchDeltaX * rotationSpeed * Time.deltaTime;
                charecter.transform.Rotate(0f, rotationAmount, 0f);
            }
        }
    }
}
