using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovement;
    [SerializeField]
    public float boundSpeed;
    [SerializeField]
    public float cameraSpeed;
    [SerializeField]
    public Transform player;
    Vector3 target;

    public Bounds bounds;
    // Start is called before the first frame update
    void Start()
    {
        bounds = new Bounds(5, 5, player.position);          
    }

    // Update is called once per frame
    void Update()
    {
        cameraSpeed = Mathf.Abs(playerMovement.horizontalVelocity.x);
        print(Time.deltaTime);
        if(player.position.x < bounds.leftBound)
        {
            bounds.Update(player.position);
            bounds.MoveLeft();


            target = new Vector3(bounds.center.x, bounds.center.y, -3.5f);
            //target = new Vector3(player.position.x, player.position.y, -3.5f);
            //transform.position = Vector3.MoveTowards(transform.position, target, cameraSpeed * Time.deltaTime);
        }else if(player.position.x > bounds.rightBound)
        {
            bounds.Update(player.position);
            bounds.MoveRight();


            target = new Vector3(bounds.center.x, bounds.center.y, -3.5f);
            //target = new Vector3(player.position.x, player.position.y, -3.5f);
            //transform.position = Vector3.MoveTowards(transform.position, target, cameraSpeed * Time.deltaTime);
        }


        //transform.position = Vector3.MoveTowards(transform.position, target, cameraSpeed * Time.deltaTime);

        print(bounds.center);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, cameraSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(bounds.center, new Vector3(bounds.width, bounds.height, 1));
    }
}


public struct Bounds
{
    public Vector2 playerLocation;
    public float width;
    public float height;
    public float leftBound;
    public float rightBound;
    public Vector2 center;

    public Bounds(int w, int h, Vector2 pos)
    {
        playerLocation = pos;
        width = w;
        height = h;
        leftBound = playerLocation.x - width / 2;
        rightBound = playerLocation.x + width / 2;
        center.x = (leftBound + rightBound) / 2;
        center.y = playerLocation.y;
    }

    public void Update(Vector2 pos)
    {
        playerLocation = pos;
        center.x = (leftBound + rightBound) / 2;
        center.y = playerLocation.y;
    }

    public void MoveLeft()
    {
        leftBound -= .4f;
        rightBound -= .4f;
        center.x = (leftBound + rightBound) / 2;
        center.y = playerLocation.y;
    }

    public void MoveRight()
    {
        leftBound += .4f;
        rightBound += .4f;
        center.x = (leftBound + rightBound) /2f;
        center.y = playerLocation.y;
    }
}