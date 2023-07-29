using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
   [SerializeField] private Slider masterSlider, musicSlider, effectsSlider;
   public InputField cheatInput;

    void Update(){
        masterSlider.value = Loader.v1;
        musicSlider.value = Loader.v2;
        effectsSlider.value = Loader.v3;
    }

    void Start()
    {
        masterSlider.value = Loader.v1;
        musicSlider.value = Loader.v2;
        effectsSlider.value = Loader.v3;
        masterSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
        musicSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));
        effectsSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeEffectsVolume(val));
    }


    public void setFullScreen(bool isFull){
        Screen.fullScreen = isFull;
        Loader.fs = isFull;
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
        case "addhalloween":
            Loader.t[1] = 1;
            cheatInput.text = "";
            break;
        case "addchristmas":
            Loader.t[2] = 1;
            cheatInput.text = "";
            break;
        case "addcherry":
            Loader.t[3] = 1;
            cheatInput.text = "";
            break;
        default:
            break;
        }
    }
}
