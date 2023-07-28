using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturepackManager : MonoBehaviour
{

    public TexturepackManager instance;

    public static string currentTexturepack = "classic";
    private static string pack = currentTexturepack;

    void Awake(){
        instance = this;
    }

    void Update(){
        if(!pack.Contains(currentTexturepack)){
            print("changes");
            changePack(pack);
        }
    }

    void Start()
    {
        GameObject.Find("MapManager").GetComponent<MapManager>().newPack = currentTexturepack;
        GameObject.Find("MapManager").GetComponent<MapManager>().wasChanged = true;
    }

    // Update is called once per frame
    void changePack(string tP)
    {
        currentTexturepack = tP;
        GameObject.Find("MapManager").GetComponent<MapManager>().newPack = currentTexturepack;
        GameObject.Find("MapManager").GetComponent<MapManager>().wasChanged = true;
    }

    public static void setPack(string newPack){
        pack = newPack;
        print("setpack: "+newPack);
    }
}
