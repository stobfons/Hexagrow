using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAudio : MonoBehaviour
{
    [SerializeField]
   private AudioClip[] audioFile;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("MapManager").GetComponent<MapManager>().texturePack.Contains("classic"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[0];
        if(GameObject.Find("MapManager").GetComponent<MapManager>().texturePack.Contains("halloween"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[1];
        if(GameObject.Find("MapManager").GetComponent<MapManager>().texturePack.Contains("christmas"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[0];
        if(GameObject.Find("MapManager").GetComponent<MapManager>().texturePack.Contains("cherry"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[2];
    }
}
