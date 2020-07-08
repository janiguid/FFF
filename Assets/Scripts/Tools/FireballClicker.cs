using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballClicker : MonoBehaviour
{
    [SerializeField] private GameObject proj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 forwardVector = Vector2.right;
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(proj, mPosition, Quaternion.identity);
        }
    }
}
