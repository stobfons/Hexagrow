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
        int.TryParse(SceneManager.GetActiveScene().name.Substring(5, SceneManager.GetActiveScene().name.Length-5), out int level); // get Level

        MapManager stacks = GameObject.Find("MapManager").GetComponent<MapManager>();
        if(level==Loader.l){
            Loader.l++;
            Loader.c+=100+(((stacks.hexStack1.childCount+stacks.hexStack2.childCount+stacks.hexStack3.childCount)-1)*10); // add Coins if new Win
        } else Loader.c+=15+(((stacks.hexStack1.childCount+stacks.hexStack2.childCount+stacks.hexStack3.childCount)-1)*2); // add Coins if Win again
        Time.timeScale = 1f;
        stopTimer = GameObject.Find("Counter").GetComponent<UnityEngine.UI.Text>().text;
        int stoppedTime = getTime(stopTimer);
        if(Loader.r.Count>=level){
            if(Loader.r[level-1]>stoppedTime){
                Loader.r[level-1] = stoppedTime;
            }
       } else Loader.r.Add(stoppedTime);
       //GameObject.Find("Record").GetComponent<UnityEngine.UI.Text>().text = convertTime(Loader.r[level-1]);
       //GameObject.Find("StoppeTime").GetComponent<UnityEngine.UI.Text>().text = stopTimer;
       setTime.stoppedTime = stopTimer;
       setTime.recordTime = convertTime(Loader.r[level-1]);
        SoundManager.Instance.PlaySound(_clip);
        Loader.save(); // saves everything 
        GameFinishUI.SetActive(true);
        MapManager.foundPath = false;
        } 
    }

    static string convertTime(int seconds){
        int min= (int) Mathf.Floor((seconds)/60);
        seconds = seconds - min*60;
        string zero = "";
        if(seconds<10){
            zero = "0";
        };
        string timer = min+":"+zero+""+seconds+" min";
        return timer;
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
        int.TryParse(minS, out int minN);
        int.TryParse(secS, out int secN);
        int time = minN*60 + secN;
        //print(time);
        return time;
    }

    public void returnMenu(){
        
        changeAudio.musicOf="LevelSelection"; 
        TexturepackManager.newSceneAudio = true;
        begin();
        SceneManager.LoadScene("LevelSelection");
    }
}
