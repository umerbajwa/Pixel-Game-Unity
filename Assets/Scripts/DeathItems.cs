using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathItems : MonoBehaviour
{
    //public Animator animator;
    
    public void OnCollisionEnter2D(Collision2D collision)
    {if(collision.gameObject.CompareTag("Player"))
        {
          //  ApplyDamage();
            collision.gameObject.GetComponent<PlayerLife>().ApplyDamage();
        }
        
    }

   
}


