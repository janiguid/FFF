using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    Transform Player;

    [SerializeField]
    Vector3 Delta;

    [SerializeField]
    private float BoundX;

    [SerializeField]
    private float BoundY;

    [SerializeField]
    private float HeightOffset;

    [SerializeField]
    float diff;
    // Start is called before the first frame update
    void Start()
    {
        diff = Player.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void LateUpdate()
    {
        Delta = Vector3.zero;

        diff = Player.transform.position.x - transform.position.x;
        if (diff > BoundX || diff < -BoundX)
        {
            if (Player.transform.position.x > transform.position.x)
            {
                Delta.x += diff - BoundX;
            }
            else if (Player.transform.position.x < transform.position.x)
            {
                Delta.x += diff + BoundX;
            }

        }

        diff = Player.transform.position.y + HeightOffset - transform.position.y;

        if (diff > BoundY || diff < -BoundY)
        {
            if (Player.transform.position.y + HeightOffset  > transform.position.y)
            {
                Delta.y += diff - BoundY;
            }
            else if (Player.transform.position.y + HeightOffset < transform.position.y)
            {
                Delta.y += diff + BoundY;
            }

        }


        transform.position += Delta;

    }
}
