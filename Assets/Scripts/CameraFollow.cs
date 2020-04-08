using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Collider2D playerCollider;
    [SerializeField]
    PlayerMovement playerMovement;
    [SerializeField]
    public float boundSpeed;
    [SerializeField]
    public float cameraSpeed;
    [SerializeField]
    public Transform player;
    Vector3 target;

    public Bounds playerBounds;
    public CustomBounds bounds;
    // Start is called before the first frame update
    void Start()
    {
        playerBounds = playerCollider.bounds;
        bounds = new CustomBounds(5, 5, player.position);          
    }

    // Update is called once per frame
    void Update()
    {
        cameraSpeed = Mathf.Abs(playerMovement.horizontalVelocity.x);
        if (playerCollider.bounds.min.x < bounds.leftBound)
        {
            //bounds.Update(player.position);
            bounds.MoveLeft(Time.deltaTime * cameraSpeed);


            target = new Vector3(bounds.center.x, bounds.center.y, -3.5f);
            //target = new Vector3(player.position.x, player.position.y, -3.5f);
            //transform.position = Vector3.MoveTowards(transform.position, target, cameraSpeed * Time.deltaTime);
        }
        else if(playerCollider.bounds.max.x > bounds.rightBound)
        {
            
            bounds.MoveRight();


            //target = new Vector3(bounds.center.x, bounds.center.y, -3.5f);
            //target = new Vector3(player.position.x, player.position.y, -3.5f);
            //transform.position = Vector3.MoveTowards(transform.position, target, cameraSpeed * Time.deltaTime);
        }

        bounds.Update(player.position);


        //target = new Vector3(bounds.center.x, bounds.center.y, -3.5f);
        //transform.position = Vector3.MoveTowards(transform.position, target, cameraSpeed * Time.deltaTime);
        transform.position = target;

        print(bounds.center);
    }

    private void LateUpdate()
    {
        //target = new Vector3(bounds.center.x, bounds.center.y, -3.5f);
        ////transform.position = Vector3.MoveTowards(transform.position, target, cameraSpeed * Time.deltaTime);
        //transform.position = target;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(bounds.center, new Vector3(bounds.width, bounds.height, 1));
    }
}


public struct CustomBounds
{
    public Vector2 playerLocation;
    public float width;
    public float height;
    public float leftBound;
    public float rightBound;
    public Vector2 center;

    public CustomBounds(int w, int h, Vector2 pos)
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
        center.x = ((leftBound + rightBound) / 2f);
        center.y = playerLocation.y + 0.7f;
    }

    public void MoveLeft(float amount)
    {
        leftBound -= amount;
        rightBound -= amount;
        //center.x = (leftBound + rightBound) / 2f;
        //center.y = playerLocation.y;
    }

    public void MoveRight()
    {
        leftBound += .01f;
        rightBound += .01f;
        //center.x = (leftBound + rightBound) /2f;
        //center.y = playerLocation.y;
    }
}