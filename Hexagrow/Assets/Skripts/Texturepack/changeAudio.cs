using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAudio : MonoBehaviour
{
    [SerializeField]
   private AudioClip[] audioFile;
   public bool playSpecial;

    void Start(){

    }

    void Update()
    {
        if(TexturepackManager.newSceneAudio){
        if(playSpecial){
            this.gameObject.GetComponent<AudioSource>().clip = audioFile[0];
        } else{

        
       if(Loader.cp.Contains("classic"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[0];
        if(Loader.cp.Contains("halloween")){
            this.gameObject.GetComponent<AudioSource>().clip = audioFile[1];
        }
        
        if(Loader.cp.Contains("christmas"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[0];
        if(Loader.cp.Contains("cherry"))
        this.gameObject.GetComponent<AudioSource>().clip = audioFile[2];
        }
        TexturepackManager.newSceneAudio = false;
        playSpecial = false;
        }
    }
}
