using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] public ParticleSystem powParticle;
    [SerializeField] public bool isPow=false;
    [SerializeField] private Animator anim;
    public float hiz = 3f;
    private bool isButtonForward = false;
    private bool isButtonBack = false;
    private bool isButtonRight = false;
    private bool isButtonLeft = false;
    public GameObject charecter;
    private float rotationSpeed = 8.5f;
    public float jumpForce = 5f;
    public bool isUp=false;
    public Rigidbody rb;
    public  bool isAttack=false;
    [SerializeField] public bool isBlock = false;


    private void Update()

    {
        
        GameObject targetObject = GameObject.Find("Player");
        Animator anim = targetObject.GetComponent<Animator>();
        Rigidbody rb =targetObject.GetComponent<Rigidbody>();
        if (isButtonForward)
        {
            //TouchingWall = false;
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
        �sRotation();
        isUp = true;

    }
    public void ForwardRelease()
    {
        isButtonForward = false;
        anim.SetBool("walk", false);
        isUp = false;

    }
    public void BackPress()
    {
        isButtonBack = true;
        anim.SetBool("walk", true);
        �sRotation();
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
        �sRotation();
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
        �sRotation();
    }
    public void leftRelease()
    {
        isButtonLeft = false;
        anim.SetBool("walk", false);
        
    }
    public void Jump()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //charecter.transform.Translate(0, 1, 0);
        }

    }
    public void Attack()
    {
        StartCoroutine(AttackAnim());
        
    }
    public void ShieldPress()
    {
        anim.SetBool("block", true);
        isBlock=true;
    }
    public void ShieldRelease()
    {
        anim.SetBool("block", false);
        isBlock=false;
    }
    public void Pow()
    {
        StartCoroutine(PowIem());
    }
    IEnumerator AttackAnim()
    {
        anim.SetBool("attack", true);
        isAttack = true;
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("attack", false);
        isAttack = false;
    }
    IEnumerator PowIem()
    {
        isPow=true;
        powParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(25f);
        powParticle.gameObject.SetActive(false);
        isPow = false;
    }


    public void �sRotation()
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
