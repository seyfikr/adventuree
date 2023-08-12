using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairwayUp : MonoBehaviour
{
    CharacterMove characterMove;
    public Transform character;
    public GameObject Character;
    public float tırmanmaHizi = 2f;
    public bool isLadder=false;
    private float yUp= 0.075f;
    Rigidbody rb;
    private void Start()
    {
        GameObject gamamaneger = GameObject.Find("CharacterMove");
        characterMove = gamamaneger.GetComponent<CharacterMove>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
            
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
           
        }

    }
    private void Update()
    {
        if (isLadder&&characterMove.isUp)
        {
            
            //float verticalInput = Input.GetAxis("Vertical");
            //Character.transform.position += Vector3.up * verticalInput * tırmanmaHizi * Time.deltaTime;
            StartCoroutine(LadderUp());
            
        }
        
    }
    IEnumerator LadderUp()
    {
        if (isLadder) { 
        Vector3 ladderUp = new Vector3(character.transform.position.x, character.transform.position.y+ yUp, character.transform.position.z);
            
            Character.transform.position = ladderUp;
            rb.useGravity = false;
            yield return new WaitForSeconds(2f);
            rb.useGravity = true;

            //yield return null;
        }
        yield return new WaitForSeconds(3f);
    }

}
