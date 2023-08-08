using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Shield : MonoBehaviour
{
    public bool isShield = false;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("EnemySword"))
        {
            //isShield = true;
            // Debug.Log("shýld");
            StartCoroutine(Shieldd());
        }
        //else
        //{
        //    isShield = false;
        //}
    }
    IEnumerator Shieldd()
    {
        isShield = true;
        yield return new WaitForSeconds(0.8f);

        isShield = false;
    }
}
