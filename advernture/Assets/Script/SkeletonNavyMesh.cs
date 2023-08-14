using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkeletonNavyMesh : MonoBehaviour
{
    [Header("Float")]
    public float skeletopHP = 100;
    public float saldirmamesafe;
    public float kovalamamesafe;
    float mesafe;

    public Slider Slider;
    CharacterMove CharacterMove;
    Animator anim;
    [SerializeField] public bool skeletonDied;
    public Transform hedefoyuncu;  
    NavMeshAgent skeletonNavymash;
    public GameObject key;
    private bool isKey=false;

    [Header("Sound")]
    [SerializeField] AudioSource damageSound;


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
            damageSound.Play();
            anim.SetBool("damage", true);
            skeletopHP -= 29;
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("damage", false);
            damageSound.Stop();
        }
        if (CharacterMove.isPow == true)
        {
            damageSound.Play();
            anim.SetBool("damage", true);
            skeletopHP -= 51;
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("damage", false);
            damageSound.Stop();
        }
       
    }
  
}
