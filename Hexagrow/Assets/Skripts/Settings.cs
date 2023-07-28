using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
   [SerializeField] private Slider masterSlider, musicSlider, effectsSlider;
   public InputField cheatInput;

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

    public void cheatCode(string cheat){
        switch (cheat)
        {
        case "test":
            print("Successfully tested!");
            cheatInput.text = "";

            break;
        case "lottery":
            CoinCounter.setCoins(1000);
            cheatInput.text = "";
            break;
        case "taxes":
            CoinCounter.setCoins(-1000);
            cheatInput.text = "";
            break;
        case "classicpack":
            TexturepackManager.setPack("classic");
            cheatInput.text = "";
            break;
        case "halloweenpack":
            TexturepackManager.setPack("halloween");
            cheatInput.text = "";
            break;
        case "christmaspack":
            TexturepackManager.setPack("christmas");
            cheatInput.text = "";
            break;
        case "cherrypack":
            TexturepackManager.setPack("cherry");
            cheatInput.text = "";
            break;
        default:
            break;
        }
    }

}
