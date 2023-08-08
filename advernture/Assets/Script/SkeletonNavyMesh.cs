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
    NavMeshAgent bearnavmsh;
    public float saldirmamesafe;
    

    void Start()
    {
        GameObject gameManager = GameObject.Find("CharacterMove");
        CharacterMove = gameManager.GetComponent<CharacterMove>();
        anim = GetComponent<Animator>();
        //hedefoyuncu = GameObject.Find("arrow");
        bearnavmsh = this.GetComponent<NavMeshAgent>();

    }


    void FixedUpdate()
    {
        if (skeletopHP < 1)
        {
            Slider.gameObject.SetActive(false);
        }
        Slider.value = skeletopHP;

        if (skeletopHP <= 0)
        {
            skeletonDied = true;
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
                bearnavmsh.isStopped = false;
                bearnavmsh.SetDestination(hedefoyuncu.transform.position);
                //yurume
                anim.SetBool("walk", true);
                anim.SetBool("attack", false);
            }
            else
            {
                bearnavmsh.isStopped = true;
                anim.SetBool("walk", false);
                anim.SetBool("attack", false);
            }
            if (mesafe < saldirmamesafe)
            {
                this.transform.LookAt(hedefoyuncu.transform.position);
                bearnavmsh.isStopped = true;
                //vurma
                anim.SetBool("walk", false);
                anim.SetBool("attack", true);




            }
        }

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
    //public void HasarVer()
    //{

    //    hedefoyuncu.GetComponent<karakter_hareket>().hasaral();

    //}
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
    //public void HasarAL()
    //{
    //    anim.SetBool("damage", true)

    //    skeletopHP -= 29;
    //}
}
