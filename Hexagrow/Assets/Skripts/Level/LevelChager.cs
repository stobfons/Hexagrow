using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChager : MonoBehaviour
{
    public static bool isChanging = false;
    public static bool hasChanged = false;
    public static string nextScene = "LevelSelection";
    private float timer = 0.5f;

    // Update is called once per frame
    void Update()
    {
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
        } //else print("not change");
    }
}
