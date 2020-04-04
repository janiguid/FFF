using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public int goTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(goTo);
    }
}
