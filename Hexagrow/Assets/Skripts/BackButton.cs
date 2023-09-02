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
    public static string getScene;
    public static string getDrag;

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
        getScene = SceneManager.GetActiveScene().name;
        
        
        if (isChanging)
        {
            timer -=Time.deltaTime;
            if ((timer) < 0)
            {   
                if(SoundManager.ready){
                    hasChanged=true;
                    isChanging = false;
                    TexturepackManager.newSceneAudio = true;
                
                    if (nextScene.Contains("Exit"))
                    {
                        Application.Quit();
                    }
                    else
                    {
                    SceneManager.LoadScene(nextScene);
                    changeAudio.musicOf=nextScene; 
                    TexturepackManager.newSceneAudio = true;
                    
                    }
                }
            }
        }
    }

    void back()
    {
        nextScene = gameObject.name;
        getDrag = nextScene;
        isChanging = true;
    }
}
