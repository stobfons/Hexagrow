using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoaderObject
{
    public int level;
    public string currentPack;
    public int[] texturePacks;
    public string[] records;
    public int coins;
    public float vol1;
    public float vol2;
    public float vol3;
    public bool fullScreen;

    public LoaderObject(){

        level = Loader.l;
        currentPack = Loader.cp;
        texturePacks = Loader.t;
        records = Loader.r;
        coins = Loader.c;
        vol1 = Loader.v1;
        vol2 = Loader.v2;
        vol3 = Loader.v3;
        fullScreen = Loader.fs;
        Debug.Log("Saved TP: "+currentPack);
    }
}
