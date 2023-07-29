using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLevelsUnlocked : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        unlock(); 
    }

    void unlock(){
int max = gameObject.transform.childCount;
        
        for(int i=1;i <= max;i++ ){
            if(i<=Loader.l){
                GameObject.Find("Level"+i).SetActive(true);
            } else {
                GameObject.Find("Level"+i).SetActive(false);
            }
        }
    }
}
