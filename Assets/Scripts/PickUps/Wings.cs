using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : PickUp
{
    [SerializeField] private float wingValue;

    public override void Collect()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerManager pMan;
            if (collision.TryGetComponent<PlayerManager>(out pMan))
            {
                pMan.IncreaseWingValue(wingValue);
            }

            StartCoroutine(Deactivate());
        }
    }


    IEnumerator Deactivate()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(4);
        gameObject.GetComponent<Collider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.SetActive(true);
    }
}
