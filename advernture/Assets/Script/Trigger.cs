using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public Slider Slider;
    Shield shield;
    CharacterMove CharacterMove;
    [SerializeField] private static int keyNumber = 0;
    [SerializeField] public GameObject key1, key2, key3;
    
    public void Start()
    {
        GameObject gameManager = GameObject.Find("ShieldCube");
        shield = gameManager.GetComponent<Shield>();
        GameObject gameManager2 = GameObject.Find("CharacterMove");
        CharacterMove = gameManager2.GetComponent<CharacterMove>();
        

    }
    private void Update()
    {
        Slider.value = Hp;
        
    }
    [SerializeField] private int Hp = 100;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DiePlane"))
        {
            SceneManager.LoadScene(0);
        }
        if(collision.gameObject.CompareTag("EnemySword"))
        {
           
            if (shield.isShield == true/*&&CharacterMove.isBlock==true*/)
            {
                //Hp += 20;
                //Debug.Log("a");
            }
            else if  (shield.isShield == false && CharacterMove.isBlock == false)
            {
                if (CharacterMove.isPow == false)
                {
                    Hp -= 20;
                }
                if (CharacterMove.isPow == true)
                {
                    Hp -= 10;
                }
           
            }

        }
        if (collision.gameObject.CompareTag("Key"))
        {
            
            if(keyNumber == 0)
            {
                key1.SetActive(true);

                Destroy(collision.gameObject);
                StartCoroutine(Key());
            }
            if (keyNumber == 1)
            {
                key2.SetActive(true);

                Destroy(collision.gameObject);
                StartCoroutine(Key());
            }
            if (keyNumber == 2)
            {
                key3.SetActive(true);

                Destroy(collision.gameObject);
                StartCoroutine(Key());
            }
        }

    }
    IEnumerator Key()
    {
        yield return new WaitForSeconds(2);
        keyNumber++;
        
    }
    
   
}
