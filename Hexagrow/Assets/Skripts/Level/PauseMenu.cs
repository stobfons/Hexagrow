using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseMenuUI;

    
    void Start(){
        Resume();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameOver.isOver && !GameFinish.isFinish){
            if(isPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        isPaused = false;
        PauseMenuUI.SetActive(isPaused);
        Time.timeScale = 1f;
    }

    void Pause(){
        isPaused = true;
        PauseMenuUI.SetActive(isPaused);
        Time.timeScale = 0f;
    }

    public void returnMenu(){
        Resume();
        
        SceneManager.LoadScene("LevelSelection");
    }
}
