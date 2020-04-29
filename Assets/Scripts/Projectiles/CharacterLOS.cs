using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLOS : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (anim)
            {
                anim.SetBool("PlayerInSight", true);
            }
            else
            {
                Debug.Log("Couldn't find animator. Check to see if it's attached.", gameObject);
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (anim)
            {
                anim.SetBool("PlayerInSight", true);
            }
            else
            {
                Debug.Log("Couldn't find animator. Check to see if it's attached.", gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (anim)
            {
                anim.SetBool("PlayerInSight", false);
            }
            else
            {
                Debug.Log("Couldn't find animator. Check to see if it's attached.", gameObject);
            }
        }

    }
}
