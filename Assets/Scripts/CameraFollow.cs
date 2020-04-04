using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    public Bounds bounds;
    // Start is called before the first frame update
    void Start()
    {
        bounds = new Bounds(5, 5, player.position);          
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x < bounds.leftBound)
        {
            bounds.Update(player.position);
            bounds.MoveLeft();
        }

        print(bounds.leftBound);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(bounds.playerLocation, new Vector3(bounds.width, bounds.height, 1));
    }
}


public struct Bounds
{
    public Vector2 playerLocation;
    public float width;
    public float height;
    public float leftBound;
    public float rightBound;

    public Bounds(int w, int h, Vector2 pos)
    {
        playerLocation = pos;
        width = w;
        height = h;
        leftBound = playerLocation.x - width / 2;
        rightBound = playerLocation.x + width / 2;
    }

    public void Update(Vector2 pos)
    {
        playerLocation = pos;
    }

    public void MoveLeft()
    {
        leftBound = playerLocation.x - width / 2;
        rightBound = playerLocation.x + width / 2;
    }
}