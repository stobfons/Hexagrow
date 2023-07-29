using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
            CameraFade.alpha = 1f;
            CameraFade.time = 0f;
            CameraFade.direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
