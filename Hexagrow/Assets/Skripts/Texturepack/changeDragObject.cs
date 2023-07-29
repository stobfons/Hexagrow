using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDragObject : MonoBehaviour
{

    [SerializeField]
    private Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("MapManager").GetComponent<MapManager>().newPack.Contains("classic"))
        this.gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite= sprites[0];
        if(GameObject.Find("MapManager").GetComponent<MapManager>().newPack.Contains("halloween"))
        this.gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite= sprites[1];
        if(GameObject.Find("MapManager").GetComponent<MapManager>().newPack.Contains("christmas"))
       this.gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite= sprites[2];
        if(GameObject.Find("MapManager").GetComponent<MapManager>().newPack.Contains("cherry"))
        this.gameObject.GetComponent<Unity.VectorGraphics.SVGImage>().sprite= sprites[3];
    }
}