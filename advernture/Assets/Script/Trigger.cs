using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    Shield shield;
    public void Start()
    {
        GameObject gameManager = GameObject.Find("ShieldCube");
        shield = gameManager.GetComponent<Shield>();
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
            if (shield.isShield == true)
            {
                //Hp += 20;
                //Debug.Log("a");
            }
            else if  (shield.isShield == false)
            {
                Hp -= 20;
            }
        }

    }
   
}
