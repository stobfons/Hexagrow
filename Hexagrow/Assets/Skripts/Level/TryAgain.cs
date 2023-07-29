using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    [SerializeField]
    public static bool isChanging = false;
    public static bool hasChanged = false;
    private float timer = 0.5f;


    void Awake(){
        CameraFade.alpha = 1f;
            CameraFade.time = 0f;
            CameraFade.direction = 1;
    }

    void Update(){
        if (isChanging)
        {
            timer -=Time.deltaTime;
            if ((timer) < 0)
            {   
                if(SoundManager.ready){
                    SoundManager.safetyVar=true;
                    isChanging = false;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
                }
            }
        }
    }

    public static void isChangingStart()
    {
        isChanging = true;
    }
}
