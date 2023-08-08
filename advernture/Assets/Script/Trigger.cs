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
            print("easd");
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

    }
   
}
