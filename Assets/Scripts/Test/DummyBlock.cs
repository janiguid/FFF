using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBlock : MonoBehaviour
{
    [SerializeField]
    private Collider2D topCollider;
    [SerializeField]
    private Collider2D bottomCollider;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer > 6)
        {
            if(topCollider.enabled == true && bottomCollider.enabled == true)
            {
                topCollider.enabled = bottomCollider.enabled = false;
            }
        }else if(timer > 2)
        {
            if(topCollider.enabled == false && bottomCollider.enabled == false)
            {
                topCollider.enabled = bottomCollider.enabled = true;
            }
        }else if(timer < 0)
        {
            timer = 8;
        }
    }
}
