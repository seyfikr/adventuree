using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour
{
    public GameObject PowButton;

    

    public Animator chestAnim; 

    
    void Awake()
    {
        
        chestAnim = GetComponent<Animator>();
        PowButton.SetActive(false);

      
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Sword"))
        {
            //StartCoroutine(OpenCloseChest());
            chestAnim.SetTrigger("open");
            PowButton.SetActive(true);
        }
    }


   
    }


