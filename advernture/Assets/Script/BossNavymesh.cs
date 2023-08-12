using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossNavymesh : MonoBehaviour
{
    public Slider Slider;
    CharacterMove CharacterMove;
    Animator anim;
    public Animator DoorAnim;
    public float BossHp = 800;
    [SerializeField] public bool BossDied;
    public Transform TargetPlayer;
    public float chaseRange;
    float range;
    NavMeshAgent skeletonNavymash;
    public float hitRange;
    //public GameObject key;
    //private bool isKey = false;
    public bool bossDamage = false;

    void Start()
    {
        GameObject gameManager = GameObject.Find("CharacterMove");
        CharacterMove = gameManager.GetComponent<CharacterMove>();
        anim = GetComponent<Animator>();
        //DoorAnim = GetComponent<Animator>();

        skeletonNavymash = this.GetComponent<NavMeshAgent>();

    }


    void FixedUpdate()
    {

        Slider.value = BossHp;

        if (BossHp <= 1)
        {
            BossDied = true;
            Slider.gameObject.SetActive(false);
            //isKey= true;
            //StartCoroutine(ÝSkey());
        }
        if (BossDied == true)
        {
            anim.SetBool("Dead", true);
            StartCoroutine(yokol());

        }
        else
        {
            range = Vector3.Distance(this.transform.position, TargetPlayer.transform.position);
            if (range < chaseRange)
            {
                this.transform.LookAt(TargetPlayer.transform.position);
                skeletonNavymash.isStopped = false;
                skeletonNavymash.SetDestination(TargetPlayer.transform.position);
                //yurume
                anim.SetBool("Walk", true);
                anim.SetBool("Attack", false);
                DoorAnim.SetBool("Door",false);
            }
            else
            {
                skeletonNavymash.isStopped = true;
                anim.SetBool("Walk", false);
                anim.SetBool("Attack", false);
            }
            if (range < hitRange)
            {
                this.transform.LookAt(TargetPlayer.transform.position);
                skeletonNavymash.isStopped = true;
                //vurma
                anim.SetBool("Walk", false);
                anim.SetBool("Attack", true);




            }
        }

    }

    //IEnumerator ÝSkey()
    //{
    //    if (!isKey)
    //    {
    //        print("spawmþla");
    //        Vector3 dusmanPozisyon = transform.position + new Vector3(0.5f, 1.2f, 0.4f);
    //        Instantiate(key, dusmanPozisyon, Quaternion.identity);
    //        isKey = true;
    //    }
    //    yield return new WaitForSeconds(6f);
    //}
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
    IEnumerator BossDamege()
    {
        bossDamage = true;
        yield return new WaitForSeconds(0.1f);
        bossDamage = false;
    }
    IEnumerator HasarAL()
    {
        if (CharacterMove.isPow == false)
        {
            anim.SetBool("damage", true);
            BossHp -= 29;
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("damage", false);
        }
        if (CharacterMove.isPow == true)
        {
            anim.SetBool("damage", true);
            BossHp -= 80;
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("damage", false);
        }

    }
}
