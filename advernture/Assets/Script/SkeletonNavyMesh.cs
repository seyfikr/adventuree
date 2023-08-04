using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkeletonNavyMesh : MonoBehaviour
{
    //public Slider Slider;

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

        anim = GetComponent<Animator>();
        //hedefoyuncu = GameObject.Find("arrow");
        bearnavmsh = this.GetComponent<NavMeshAgent>();

    }


    void FixedUpdate()
    {
        //Slider.value = bearhp;

        if (skeletopHP <= 0)
        {
            skeletonDied = true;
        }
        if (skeletonDied == true)
        {
            anim.SetBool("died", true);
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
                anim.SetBool("yuruyor", true);
                anim.SetBool("hit", false);
            }
            else
            {
                bearnavmsh.isStopped = true;
                anim.SetBool("yuruyor", false);
                anim.SetBool("hit", false);
            }
            if (mesafe < saldirmamesafe)
            {
                this.transform.LookAt(hedefoyuncu.transform.position);
                bearnavmsh.isStopped = true;
                //vurma
                anim.SetBool("yuruyor", false);
                anim.SetBool("hit", true);




            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            skeletopHP -= 25;
            Debug.Log("s0");
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
    public void HasarAL()
    {
        skeletopHP -= Random.Range(17f, 25f);
    }
}
