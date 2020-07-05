using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageClicker : MonoBehaviour
{
    [SerializeField] private LayerMask layerToTest;
    public float xForce;
    public float yForce;
    CameraFollow cam;
    // Update is called once per frame
    void Update()
    {
        Vector2 forwardVector = Vector2.right;
        if (Input.GetMouseButtonDown(0))
        {
            print("Clicked");
            Vector2 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D ray = Physics2D.Raycast(mPosition, Vector2.down);

            if(ray.collider != null)
            {
                ray.collider.gameObject.GetComponent<IPushable>().ApplyForce(xForce, yForce);
            }
        }
    }
}
