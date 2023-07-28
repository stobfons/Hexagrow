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
        if(MapManager.isPack.Contains("classic"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[0];
        if(MapManager.isPack.Contains("halloween"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[1];
        if(MapManager.isPack.Contains("christmas"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[0];
        if(MapManager.isPack.Contains("cherry"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[2];
    }
}
