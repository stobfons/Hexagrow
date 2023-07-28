using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public Text coinText;
    public static int currentCoins = 100;
    private static int coins = currentCoins;

    void Awake(){
        instance = this;
    }

    void Update(){
        print(coins+" : "+currentCoins);
        if(coins!=currentCoins){
                changeCoins();
            }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //coinText = GetComponent<Text>();
        coinText.text = ""+currentCoins;
    }

   private void changeCoins()
    {
        currentCoins = coins;
        coinText.text = ""+currentCoins;
    }

    public static void setCoins(int v){
        coins += v;
        if((coins)>10000){
            coins = 10000;
            }
        if(((coins)<0)){
            coins = 0;
        }
        print(coins);
        
    }
}
