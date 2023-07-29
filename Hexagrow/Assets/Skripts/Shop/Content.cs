using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Content : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Loader.t[0]==0){
            if(GameObject.Find("classic")!=null)
            GameObject.Find("classic").SetActive(true);
        } else {
            if(GameObject.Find("classic")!=null)
            GameObject.Find("classic").SetActive(false);
        }
        if(Loader.t[1]==0){
            GameObject.Find("halloween").SetActive(true);
        } else GameObject.Find("halloween").SetActive(false);
        if(Loader.t[2]==0){
            GameObject.Find("christmas").SetActive(true);
        }else GameObject.Find("christmas").SetActive(false);
        if(Loader.t[3]==0){
            GameObject.Find("cherry").SetActive(true);
        }else GameObject.Find("cherry").SetActive(false);
    }

    public static void halloween(){
        Shop.pack = "halloween";
    }
    public static void christmas(){
        Shop.pack = "christmas";
    }
    public static void cherry(){
        Shop.pack = "cherry";
    }
}
