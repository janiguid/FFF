using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeTest : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Camera mainCam;

    [Header("Timers")]
    [SerializeField] private float initialCameraShakeTime;
    [SerializeField] private float cameraShakeTime;
    [SerializeField] private bool beginCameraShakeTime;

    [Header ("Shake Amount")]
    [SerializeField] private float minXShake;
    [SerializeField] private float maxXShake;
    [SerializeField] private float minYShake;
    [SerializeField] private float maxYShake;


    [Header("Zoom Effect")]
    [SerializeField] private float targetSize;
    [SerializeField] private float zoomSpeed;
    private float initialSize;
    private float throwaway;
    //we need these because otherwise "Camera.cs"'s LateUpdate function 
    //will be affected by this Update function. This is because they
    //affect the camera's transform. These variables are to ensure that
    //when in combat, use this camera's change in position but use regular
    //camera tracking when out of combat
    [Header("Combat Mode")]
    [SerializeField] private bool combatMode;
    [SerializeField] private float combatModeTimer;
    [SerializeField] private float combatLength;

    // Start is called before the first frame update
    void Start()
    {
        if (targetSize == 0) targetSize = 4;
        if (zoomSpeed == 0) zoomSpeed = 10;
        if (playerTransform == null) FindObjectOfType<PlayerController>();
        if (mainCam) initialSize = mainCam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null) this.enabled = false;
        if(combatModeTimer > 0)
        {
            if(mainCam.orthographicSize >= targetSize)
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, targetSize, ref throwaway, zoomSpeed * Time.deltaTime);
            combatModeTimer -= Time.deltaTime;

        }else if(combatModeTimer <= 0 && combatMode == true)
        {
            combatMode = false;
        }

        if(combatMode == false && mainCam.orthographicSize < initialSize)
        {
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, initialSize, ref throwaway, zoomSpeed * Time.deltaTime);
        }

        if (beginCameraShakeTime)
        {
            cameraShakeTime -= Time.deltaTime;
            ShakeCamera();
        }

        if (cameraShakeTime <= 0)
        {
            beginCameraShakeTime = false;
        }

        if (beginCameraShakeTime == false && combatMode)
        {
            Vector3 target = playerTransform.localPosition;
            target.z = transform.localPosition.z;
            if (transform.localPosition != target)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, 0.1f);
            }
        }

    }

    public void StartShake()
    {
        beginCameraShakeTime = true;
        cameraShakeTime = initialCameraShakeTime;
        combatMode = true;
        combatModeTimer = combatLength;
    }

    void ShakeCamera()
    {
        transform.localPosition += new Vector3(Random.Range(minXShake, maxXShake), Random.Range(minYShake, maxYShake));
    }
}
