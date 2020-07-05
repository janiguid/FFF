using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounder : MonoBehaviour
{
    [SerializeField] private Rigidbody2D MyRB2D;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float gravityScale;
    [SerializeField] private Vector2 verticalVector;



    // Update is called once per frame
    void Update()
    {
        if (!isGrounded)
        {
            verticalVector.x = MyRB2D.velocity.x;
            verticalVector.y -= Time.deltaTime;
            MyRB2D.velocity = verticalVector;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
