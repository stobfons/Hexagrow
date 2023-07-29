using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    [SerializeField]
    string nextScene = "Menu";
    public static bool change = false;
    public static bool isChanging = false;
    public static bool hasChanged = false;
    private float timer = 0.5f;

    public static void setChange(){
        change= true;
    }

    void Awake(){
        CameraFade.alpha = 1f;
            CameraFade.time = 0f;
            CameraFade.direction = 1;
    }

    void Update(){
        if(change){
            back();
            change=false;
        }
        ///////
        if (isChanging)
        {
            timer -=Time.deltaTime;
            if ((timer) < 0)
            {   
                if(SoundManager.ready){
                    hasChanged=true;
                    isChanging = false;
                
                    if (nextScene.Contains("Exit"))
                    {
                        Application.Quit();
                    }
                    else
                    {
                    SceneManager.LoadScene(nextScene); 
                    }
                }
            }
        }
    }

    void back()
    {
        nextScene = gameObject.name;
        isChanging = true;
    }
}
