using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool isOver = false;
    public GameObject GameOverUI;

    void Update()
    {
        if(isOver){
            Over();
        }
    }

    void Start(){
        Resume();
    }

    public void Resume(){
        isOver = false;
        GameOverUI.SetActive(isOver);
        Time.timeScale = 1f;
    }

    void Over(){
        isOver = true;
        GameOverUI.SetActive(isOver);
        Time.timeScale = 0f;
    }

    public void returnMenu(){
        Resume();
        SceneManager.LoadScene("Menu");
    }
}
