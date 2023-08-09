using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class setTime : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timerText;
    public static string stoppedTime = "unknown";
    public static string recordTime = "unknown";
    void Update()
    {
        if(gameObject.name.Contains("Record")){
            timerText.text = recordTime;
        }
        if(gameObject.name.Contains("StoppedTime")){
            timerText.text = stoppedTime;
        }
    }
}
