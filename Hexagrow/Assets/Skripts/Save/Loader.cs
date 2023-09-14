using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Loader : MonoBehaviour
	

{
    public static int l = 1;
    public static string cp = "classic";
    public static int[] t = {1,0,0,0};
    public static List<int> r = new List<int>();
    public static int c = 0;
    public static float v1 = 1;
    public static float v2 = 1;
    public static float v3 = 1;
    public static bool fs = true;

    void Update(){
{
            SoundManager.Instance.ChangeMasterVolume(v1);
            SoundManager.Instance.ChangeMusicVolume(v2);
            SoundManager.Instance.ChangeEffectsVolume(v3);

        if(!TexturepackManager.currentTexturepack.Contains(cp)){
            TexturepackManager.setPack(cp);
        }
        if(CoinCounter.currentCoins!=c){
            CoinCounter.setCoins(c);
        }
    }
    }

    public void loadNow(){
        Debug.Log("Loaded");

        LoaderObject data = SaveGame.load();
        if(data == null){
            Debug.Log("Error");
        }
        l = data.level;
        t = data.texturePacks;
        cp = data.currentPack;
        r = data.records;
        c = data.coins;
        v1 = data.vol1;
        v2 = data.vol2;
        v3 = data.vol3;
        fs = data.fullScreen;
        Debug.Log("Loaded Sound: "+v1);
    }

    public static void save(){
        //Debug.Log("saved");
        SaveGame.save(new LoaderObject());
    }
}
