using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public int goTo, x, y;
    private GameObject player; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = GameObject.FindWithTag("Player");
            player.transform.position = new Vector2(x, y);

            SceneManager.LoadScene(goTo);

        }
    }

}
