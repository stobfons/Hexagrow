using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTexture : MonoBehaviour
{
    public Sprite newTexture;
    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("MapManager").GetComponent<MapManager>().texturePack.Contains("halloween"))
        this.gameObject.GetComponent<SpriteRenderer>().sprite = newTexture;

    }
}
