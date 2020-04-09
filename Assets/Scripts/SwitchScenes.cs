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
        SceneManager.LoadScene(goTo);
        player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector2(x, y);
        Debug.Log(player.transform.position);
    }

}
