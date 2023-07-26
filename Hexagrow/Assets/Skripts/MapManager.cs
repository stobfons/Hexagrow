using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;
    [SerializeField]
   private TileBase[] emptyTiles;
   [SerializeField]
   private TileBase[] startTiles;
   [SerializeField]
   private TileBase[] goalTiles;
   [SerializeField]
   private TileBase[] barrierTiles;
    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;
    public string texturePack = "classic";
    public bool texturepackAktivieren = true;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
       

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition);


           string nameTag = dataFromTiles[clickedTile].nameTag;

            print("At position "+ gridPosition +" there is a "+ clickedTile +" called Tag: "+ nameTag);

            //if(nameTag=="empty"){
             //   map.SetTile(gridPosition, emptyTiles[Random.Range(0, 2)]);
                //map.SetTile(gridPosition, empty1);
           // }
            // map.SetTileFlags(gridPosition, TileFlags.None);
            //  map.SetColor(gridPosition, Color.black);

            //   float walkingSpeed = dataFromTiles[clickedTile].walkingSpeed;

        }
    }

     public TileData GetTileData(Vector3Int tilePosition){
        TileBase tile = map.GetTile(tilePosition);

        if (tile == null)
            return null;
        else
            return dataFromTiles[tile];
    }

    public void Start(){
        Vector3Int gridPosition = new Vector3Int(0,0,0);
        string nameTag;
        int pack = 0;
        if(texturepackAktivieren){
        for(gridPosition.x = -50; gridPosition.x<50; gridPosition.x++){
            for(gridPosition.y = -50; gridPosition.y<50; gridPosition.y++){
                if(map.GetTile(gridPosition) != null){
                 nameTag = dataFromTiles[map.GetTile(gridPosition)].nameTag;
                 if(nameTag!=null){

                if(texturePack.Contains("classic")) pack = 0;
                if(texturePack.Contains("halloween")) pack = 1;
                if(texturePack.Contains("christmas")) pack = 2;
                if(texturePack.Contains("cherry")) pack = 3;


                  if(nameTag.Contains("empty")){
                    map.SetTile(gridPosition, emptyTiles[Random.Range((0+(pack*2)), (2+(pack*2)))]);
                  } 
                  if(nameTag.Contains("start")){
                    map.SetTile(gridPosition, startTiles[0+pack]);
                  }
                  if(nameTag.Contains("goal")){
                    map.SetTile(gridPosition, goalTiles[0+pack]);
                  } 
                  if(nameTag.Contains("barrier")){
                    map.SetTile(gridPosition, barrierTiles[0+pack]);
                  }  
                  }
                  }
            }
        }
        }
    }   
}
