using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //turns vsync off
        QualitySettings.vSyncCount = 0;

        //targets 60 fps
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
