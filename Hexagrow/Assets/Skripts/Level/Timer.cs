using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class Timer : MonoBehaviour
{

    public Text timerText;
    public float currentTime = 0;
    private float min = 0;
    private float sek = 0;


    void Update(){
        currentTime -= Time.deltaTime;
        sek= Mathf.Floor(currentTime*-1)-(min*60);
        min=Mathf.Floor((currentTime*-1)/60);
        
        if(sek<10){
            timerText.text = min+":"+"0"+sek+" min";
        } else timerText.text = min+":"+sek+" min";
    }

    void Start()
    {
        //coinText = GetComponent<Text>();
        timerText.text = "0:00 min";
    }

}
