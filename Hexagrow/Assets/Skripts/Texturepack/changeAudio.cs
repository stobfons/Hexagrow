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
       if(Loader.cp.Contains("classic"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[0];
        if(Loader.cp.Contains("halloween"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[1];
        if(Loader.cp.Contains("christmas"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[0];
        if(Loader.cp.Contains("cherry"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[2];
    }
}
