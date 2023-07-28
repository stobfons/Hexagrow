using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource _musicSource, _effectsSource;
    private static int c = 0;

    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    void Start(){
        _musicSource.Play();
        print("Music should play Start");
    }

    void Update(){
        if(!_musicSource.isPlaying){
            Play();
            print("Music should play Update");
        }
        if(PauseMenu.isPaused){
            Pause();
        } else Resume();

        if(DragAndDropToScene.isChanging){
            print("Sound mutes");
            _musicSource.volume=2.5f-Time.deltaTime;
        } else {
            _musicSource.volume = 1;
            print("Sound starts");
            }
    }

    public void PlaySound(AudioClip clip){
        _effectsSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value){
        AudioListener.volume = value;
    }

    public void ChangeMusicVolume(float value){
        _musicSource.volume = value;
    }
    public void ChangeEffectsVolume(float value){
        _effectsSource.volume = value;
    }

    private void Play(){
        _musicSource.Play();
    }

    public void Pause(){
            if(c<1){
            _musicSource.pitch *=.5f;
            _musicSource.volume *=.7f;
            c=1;;
        } 
    }

    public void Resume(){
            if(c>0){
            _musicSource.pitch /=.5f;
            _musicSource.volume /=.7f;
            c=0;
        } 
    }
    
}
