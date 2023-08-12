using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
using JetBrains.Annotations;

public class Trigger : MonoBehaviour
{
    BossNavymesh bossNavymesh;
    public Slider Slider;
    Shield shield;
    CharacterMove CharacterMove;
    [SerializeField] private static int keyNumber = 0;
    [SerializeField] public GameObject key1, key2, key3;
    [SerializeField] public Animator anim;
    [SerializeField] public GameObject cam;
    private bool bossDamage=false;

    public void Start()
    {
        GameObject gameManager = GameObject.Find("ShieldCube");
        shield = gameManager.GetComponent<Shield>();
        GameObject gameManager3 = GameObject.Find("Boss");
        bossNavymesh = gameManager3.GetComponent<BossNavymesh>();
        GameObject gameManager2 = GameObject.Find("CharacterMove");
        CharacterMove = gameManager2.GetComponent<CharacterMove>();
        

    }
    private void Update()
    {
        Debug.Log(bossNavymesh.bossDamage);
        Slider.value = Hp;
        
        if (keyNumber == 3)
        {
            cam.SetActive(true);
            anim.SetBool("Door", true);
            StartCoroutine(Cam());
            keyNumber++;
        }
        if(bossNavymesh.bossDamage == true&& shield.isShield == false && CharacterMove.isBlock == false)
        {
            if (CharacterMove.isPow == false)
            {
                Hp -= 2;
            }
            if (CharacterMove.isPow == true)
            {
                Hp -= 1;
            }
        }
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
        
        if (collision.gameObject.CompareTag("boss"))
        {

            if (shield.isShield == true/*&&CharacterMove.isBlock==true*/)
            {
                //Hp += 20;
                //Debug.Log("a");
            }
            else if (shield.isShield == false && CharacterMove.isBlock == false)
            {
                if (CharacterMove.isPow == false)
                {
                    Hp -= 30;
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
    public void HasarVer()
    {
        StartCoroutine(BossDamege());
    }
    IEnumerator Key()
    {
        yield return new WaitForSeconds(2);
        keyNumber++;
        
    }
    IEnumerator Cam()
    {
        yield return new WaitForSeconds(4);
        for (int i = 0; i < 60; i++)
        {
            cam.transform.eulerAngles -= new Vector3(0, 3, 0);
            yield return new WaitForSeconds(0.05f);

        }
        yield return new WaitForSeconds(3);
        cam.SetActive(false);

    }
    IEnumerator BossDamege()
    {
        bossDamage = true;
        yield return new WaitForSeconds(0.5f);
        bossDamage = false;
    }


}
