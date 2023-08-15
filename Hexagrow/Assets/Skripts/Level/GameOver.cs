using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool isOver = false;
    public GameObject GameOverUI;
    [SerializeField] private AudioClip _clip;
    private static int c = 0;

    void Update()
    {
        if(isOver){
            Over();
        } else Resume();
    }

    void Start(){
        Resume();
    }

    public void Resume(){
        isOver = false;
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
        c=0;
    }

    void Over(){
        if(c==0){
            c=1;
        GameOverUI.SetActive(true);
        Time.timeScale = 1f;
        SoundManager.Instance.PlaySound(_clip);
        }
    }

    public void returnMenu(){
        
        changeAudio.musicOf="LevelSelection"; 
        TexturepackManager.newSceneAudio = true;
        Resume();
        SceneManager.LoadScene("LevelSelection");
    }
}
