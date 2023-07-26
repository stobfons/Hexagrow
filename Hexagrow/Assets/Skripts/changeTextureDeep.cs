using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTextureDeep : MonoBehaviour
{

    [SerializeField]
   private Sprite[] sprites;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("MapManager").GetComponent<MapManager>().texturePack.Contains("classic"))
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        if(GameObject.Find("MapManager").GetComponent<MapManager>().texturePack.Contains("halloween"))
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        if(GameObject.Find("MapManager").GetComponent<MapManager>().texturePack.Contains("christmas"))
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        if(GameObject.Find("MapManager").GetComponent<MapManager>().texturePack.Contains("cherry"))
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
    }
}
