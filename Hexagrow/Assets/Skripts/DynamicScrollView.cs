using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicScrollView : MonoBehaviour
{
   [SerializeField]
   private Transform scrollViewContent;

   [SerializeField]
   private GameObject prefab;

   [SerializeField]
   private List<Sprite> texturePacks;

   private void Start(){
    foreach (Sprite texturePack in texturePacks){
        GameObject newTexturePack = Instantiate(prefab, scrollViewContent);
        if(newTexturePack.TryGetComponent<ScrollViewItem>(out ScrollViewItem texture)){
        texture.changeImage(texturePack);
        }
    }
   }
}
