using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool isOver = false;
    public GameObject GameOverUI;
    [SerializeField] private AudioClip _clip;
    public string stopTimer;
    private static int c = 0;

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
        if(c==0){
            c=1;
        GameOverUI.SetActive(isOver);
        Time.timeScale = 1f;
        stopTimer = GameObject.Find("Counter").GetComponent<UnityEngine.UI.Text>().text;
        print(stopTimer);
        SoundManager.Instance.PlaySound(_clip);
        }
    }

    public void returnMenu(){
        Resume();
        SceneManager.LoadScene("Menu");
    }
}
