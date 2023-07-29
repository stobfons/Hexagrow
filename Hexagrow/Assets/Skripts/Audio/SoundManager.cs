using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource _musicSource, _effectsSource;
    private static int c = 0;
    public static bool ready = false;
    public static bool temps = true;
    private float tempVolume;
    public static float v1,v2,v3;

    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    void Start(){
        //tempVolume = Loader.v2;
    }
    
    public void PlaySound(AudioClip clip){
        _effectsSource.PlayOneShot(clip);
    }

    void Update(){
      if(!_musicSource.isPlaying)
       _musicSource.Play();

        if(PauseMenu.isPaused){
            Pause();
        } else Resume();

        if(GameOver.isOver){
            Over();
        } else Continue();

        if((DragAndDropToScene.isChanging || BackButton.isChanging)&&!ready){
            temps = false;
           ChangeMusicVolume(_musicSource.volume*0.98f);
           print( _musicSource.volume);
           if(_musicSource.volume<0.1f){
            _musicSource.Stop();
            ready=true;
            print("Temp: "+tempVolume);
            Loader.v2=tempVolume;
           }
        } else{
             temps = true;
            if(DragAndDropToScene.hasChanged || BackButton.hasChanged){
             ready = false;
            
            }
        }
    }


    public void ChangeMasterVolume(float value){
        AudioListener.volume = value;
        Loader.v1 = value;
    }

    public void ChangeMusicVolume(float value){
        _musicSource.volume = value;
        Loader.v2 = value;
        if(temps){
            tempVolume = value;
        }
    }
    public void ChangeEffectsVolume(float value){
        _effectsSource.volume = value;
        Loader.v3 = value;
    }

    private void Play(){
        _musicSource.Play();
    }

    public void Pause(){
            if(c<1){
            _musicSource.pitch *=.5f;
            _musicSource.volume *=.7f;
            c=1;
        } 
    }

    public void Resume(){
            if(c>0){
            _musicSource.pitch /=.5f;
            _musicSource.volume /=.7f;
            c=0;
        } 
    }

    public void Over(){
            if(c<1){
            _musicSource.pitch *=.5f;
            _effectsSource.pitch = 1f;
            _musicSource.volume *=.1f;
            c=1;
            }
    }

    public void Continue(){
            if(c>0){
            _musicSource.pitch /=.5f;
            _musicSource.volume /=.1f;
            c=0;
            }
    }
    
}
