using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    public static bool isFinish = false;
    public GameObject GameFinishUI;
    [SerializeField] private AudioClip _clip;
    public string stopTimer;
    private static int c = 0;

    void Update()
    {
        if(isFinish){
            Finish();
        } else Start();
    }

    void Start(){
        
        begin();
    }

    public void begin(){
        isFinish = false;
        GameFinishUI.SetActive(false);
        Time.timeScale = 1f;
        c=0;
    }

    void Finish(){
        if(c==0){
            c=1;
        //print(int.Parse((SceneManager.GetActiveScene().name).Substring(4, SceneManager.GetActiveScene().name.Length-4))); // get Level
        int level = 1;

        MapManager stacks = GameObject.Find("MapManager").GetComponent<MapManager>();
        if(level==Loader.l){
            Loader.l++;
            Loader.c+=100+(((stacks.hexStack1.childCount+stacks.hexStack2.childCount+stacks.hexStack3.childCount)-1)*10); // add Coins if new Win
        } else Loader.c+=15+(((stacks.hexStack1.childCount+stacks.hexStack2.childCount+stacks.hexStack3.childCount)-1)*2); // add Coins if Win again
        Time.timeScale = 1f;
        stopTimer = GameObject.Find("Counter").GetComponent<UnityEngine.UI.Text>().text;
        int stoppedTime = getTime(stopTimer);
        //if(Loader.r[level]>stoppedTime){
        //    Loader.r[level] = stoppedTime;
       // }
        SoundManager.Instance.PlaySound(_clip);
        Loader.save(); // saves everything 
        GameFinishUI.SetActive(true);
        }

        
       
    }

    int getTime(string t){
        string minS = "";
        string secS = "";
        bool s=false;
        for(int i=0; i<t.Length-4; i++){ // t = "1:45 min" -> i to 1:45
            if(s){
                secS+=t[i];
            } else {
                if(t[i]!=':'){
                    minS+=t[i];
                } else s = true; 
            }
        }
        return ((int.Parse(minS)*60)+int.Parse(secS));
    }

    public void returnMenu(){
        
        changeAudio.musicOf="LevelSelection"; 
        TexturepackManager.newSceneAudio = true;
        begin();
        SceneManager.LoadScene("LevelSelection");
    }
}
