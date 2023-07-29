using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
   public static string pack = "classic";
   [SerializeField] private Sprite[] sprites;

   void Update(){
    if(pack.Contains("halloween"))
        this.gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite= sprites[0]; 
    if(pack.Contains("christmas"))
        this.gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite= sprites[1];
    if(pack.Contains("cherry"))
        this.gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite= sprites[2];
   }
}

