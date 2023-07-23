using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
   [SerializeField] private Slider masterSlider, musicSlider, effectsSlider;

    void Start()
    {
        SoundManager.Instance.ChangeMasterVolume(masterSlider.value);
        SoundManager.Instance.ChangeMusicVolume(musicSlider.value);
        SoundManager.Instance.ChangeEffectsVolume(effectsSlider.value);
        masterSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
        musicSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));
        effectsSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeEffectsVolume(val));

    }

    public void setFullScreen(bool isFull){
        Screen.fullScreen = isFull;
    }

}
