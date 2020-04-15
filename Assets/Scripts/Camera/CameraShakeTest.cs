using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeTest : MonoBehaviour
{
    public Transform playerTransform;

    public float initialCameraShakeTime;
    public float cameraShakeTime;
    public bool beginCameraShakeTime;

    public float minXShake;
    public float maxXShake;

    public float minYShake;
    public float maxYShake;

    //we need these because otherwise "Camera.cs"'s LateUpdate function 
    //will be affected by this Update function. This is because they
    //affect the camera's transform. These variables are to ensure that
    //when in combat, use this camera's change in position but use regular
    //camera tracking when out of combat
    public bool combatMode;
    public float combatModeTimer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(combatModeTimer > 0)
        {
            combatModeTimer -= Time.deltaTime;
        }else if(combatModeTimer <= 0 && combatMode == true)
        {
            combatMode = false;
        }

        if (beginCameraShakeTime)
        {
            cameraShakeTime -= Time.deltaTime;
            ShakeCamera();
        }

        if(cameraShakeTime <= 0)
        {
            beginCameraShakeTime = false;
        }

        if(beginCameraShakeTime == false && combatMode)
        {
            Vector3 target = playerTransform.position;
            target.z = transform.position.z;
            if (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
            }    
        }

    }

    public void StartShake()
    {
        beginCameraShakeTime = true;
        cameraShakeTime = initialCameraShakeTime;
        combatMode = true;
        combatModeTimer = 2f;
    }

    void ShakeCamera()
    {
        transform.position += new Vector3(Random.Range(minXShake, maxXShake), Random.Range(minYShake, maxYShake));
    }
}
