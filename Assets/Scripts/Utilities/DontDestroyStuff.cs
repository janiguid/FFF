using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyStuff : MonoBehaviour
{
    [SerializeField] string objTag;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(objTag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}