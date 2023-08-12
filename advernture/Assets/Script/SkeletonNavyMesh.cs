using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkeletonNavyMesh : MonoBehaviour
{
    
    public Slider Slider;
    CharacterMove CharacterMove;
    Animator anim;
    public float skeletopHP = 100;
    bool skeletonDied;
    public Transform hedefoyuncu;
    public float kovalamamesafe;
    float mesafe;
    NavMeshAgent skeletonNavymash;
    public float saldirmamesafe;
    public GameObject key;
    private bool isKey=false;
    

    void Start()
    {
        GameObject gameManager = GameObject.Find("CharacterMove");
        CharacterMove = gameManager.GetComponent<CharacterMove>();
        anim = GetComponent<Animator>();

        skeletonNavymash = this.GetComponent<NavMeshAgent>();

    }


    void FixedUpdate()
    {
       
        Slider.value = skeletopHP;

        if (skeletopHP <= 1)
        {
            skeletonDied = true;
            Slider.gameObject.SetActive(false);
            //isKey= true;
            StartCoroutine(ÝSkey());
        }
        if (skeletonDied == true)
        {
            anim.SetBool("deat", true);
            StartCoroutine(yokol());
            
        }
        else
        {
            mesafe = Vector3.Distance(this.transform.position, hedefoyuncu.transform.position);
            if (mesafe < kovalamamesafe)
            {
                this.transform.LookAt(hedefoyuncu.transform.position);
                skeletonNavymash.isStopped = false;
                skeletonNavymash.SetDestination(hedefoyuncu.transform.position);
                //yurume
                anim.SetBool("walk", true);
                anim.SetBool("attack", false);
            }
            else
            {
                skeletonNavymash.isStopped = true;
                anim.SetBool("walk", false);
                anim.SetBool("attack", false);
            }
            if (mesafe < saldirmamesafe)
            {
                this.transform.LookAt(hedefoyuncu.transform.position);
                skeletonNavymash.isStopped = true;
                //vurma
                anim.SetBool("walk", false);
                anim.SetBool("attack", true);




            }
        }

    }
   
    IEnumerator ÝSkey()
    {
        if (!isKey)
        {
            print("spawmþla");
            Vector3 dusmanPozisyon = transform.position+ new Vector3(0.5f,1.2f,0.4f);
            Instantiate(key, dusmanPozisyon, Quaternion.identity);
            isKey = true;
        }
        yield return new WaitForSeconds(6f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            if (CharacterMove.isAttack == true)
            {
                StartCoroutine(HasarAL());
            }
          
            
        }


    }
  
    IEnumerator yokol()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
        Destroy(this.gameObject);
    }
    IEnumerator HasarAL()
    {
        if (CharacterMove.isPow == false)
        {
            anim.SetBool("damage", true);
            skeletopHP -= 29;
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("damage", false);
        }
        if (CharacterMove.isPow == true)
        {
            anim.SetBool("damage", true);
            skeletopHP -= 51;
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("damage", false);
        }
       
    }
  
}
