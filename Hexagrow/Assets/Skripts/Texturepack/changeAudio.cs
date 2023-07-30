using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAudio : MonoBehaviour
{
    [SerializeField]
   private AudioClip[] audioFile;
   public static string musicOf;

    void Update()
    {
        if(TexturepackManager.newSceneAudio){
            print(musicOf);
            if(musicOf.Contains("Menu")){
                if(Loader.cp.Contains("classic"))
                    this.gameObject.GetComponent<AudioSource>().clip = audioFile[0];
                if(Loader.cp.Contains("halloween"))
                    this.gameObject.GetComponent<AudioSource>().clip = audioFile[1];
                if(Loader.cp.Contains("christmas"))
                    this.gameObject.GetComponent<AudioSource>().clip = audioFile[2];
                if(Loader.cp.Contains("cherry"))
                    this.gameObject.GetComponent<AudioSource>().clip = audioFile[3];
            }
            if(musicOf.Contains("Level")){
                if(Loader.cp.Contains("classic"))
                    this.gameObject.GetComponent<AudioSource>().clip = audioFile[4];
                if(Loader.cp.Contains("halloween"))
                    this.gameObject.GetComponent<AudioSource>().clip = audioFile[5];
                if(Loader.cp.Contains("christmas"))
                    this.gameObject.GetComponent<AudioSource>().clip = audioFile[6];
                if(Loader.cp.Contains("cherry"))
                    this.gameObject.GetComponent<AudioSource>().clip = audioFile[7];
            }
            if(musicOf.Contains("Title")){
                this.gameObject.GetComponent<AudioSource>().clip = audioFile[8];
            }
            if(musicOf.Contains("Settings")){ 
                        this.gameObject.GetComponent<AudioSource>().clip = audioFile[9];
            }
            if(musicOf.Contains("Shop")){ 
                        this.gameObject.GetComponent<AudioSource>().clip = audioFile[10];
            }
            if(musicOf.Contains("LevelSelection")){ 
                        this.gameObject.GetComponent<AudioSource>().clip = audioFile[11];
            }    
        TexturepackManager.newSceneAudio = false;
        }
    }
}
