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
    private TileBase[] pathTiles;

    [SerializeField]
    private List<TileData> tileDatas;
    [SerializeField]
    public Transform hexStack1;
    [SerializeField]
    public Transform hexStack2;
    [SerializeField]
    public Transform hexStack3;

    private Dictionary<TileBase, TileData> dataFromTiles;
    private string texturePack = "classic";
    public bool wasChanged = false;
    public string newPack = "classic";
    public static string isPack;

    public void Start()
    {
        changeTextures();
    }

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
        if (wasChanged)
        { //Texturepack
            print("Changed MapManager");
            wasChanged = false;
            texturePack = newPack;
            isPack = texturePack;
            changeTextures();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition);

            if (clickedTile != null)
            {
                string nameTag = dataFromTiles[clickedTile].nameTag;

                print(
                    "At position " + gridPosition + " there is a " + clickedTile + " called Tag: " + nameTag
                );
                if (clickedTile.name.Contains("1"))
                {
                    print("Can connect to 4");
                }
            }
            else
                print("At position " + gridPosition + " there is null!");
        }
    }

    public TileData GetTileData(Vector3Int tilePosition)
    {
        TileBase tile = map.GetTile(tilePosition);

        if (tile == null)
            return null;
        else
            return dataFromTiles[tile];
    }







































    void changeTextures()
    {
        Vector3Int gridPosition = new Vector3Int(0, 0, 0);
        string nameTag;
        int pack = 0;
        
            for (gridPosition.x = -50; gridPosition.x < 50; gridPosition.x++)
            {
                for (gridPosition.y = -50; gridPosition.y < 50; gridPosition.y++)
                {
                    if (map.GetTile(gridPosition) != null)
                    {
                        nameTag = dataFromTiles[map.GetTile(gridPosition)].nameTag;
                        if (nameTag != null)
                        {
                            if (texturePack.Contains("classic"))
                                pack = 0;
                            if (texturePack.Contains("halloween"))
                                pack = 1;
                            if (texturePack.Contains("christmas"))
                                pack = 2;
                            if (texturePack.Contains("cherry"))
                                pack = 3;
                            print(pack);

                            if (nameTag.Contains("empty"))
                            {
                                map.SetTile(
                                    gridPosition,
                                    emptyTiles[Random.Range((0 + (pack * 2)), (2 + (pack * 2)))]
                                );
                            }
                            if (nameTag.Contains("start"))
                            {
                                map.SetTile(gridPosition, startTiles[0 + pack]);
                            }
                            if (nameTag.Contains("goal"))
                            {
                                map.SetTile(gridPosition, goalTiles[0 + pack]);
                            }
                            if (nameTag.Contains("barrier"))
                            {
                                map.SetTile(gridPosition, barrierTiles[0 + pack]);
                            }
                            if (nameTag.Contains("path"))
                            {
                                map.SetTile(  gridPosition, pathTiles[getTile(map.GetTile(gridPosition).name) + (pack * 53)]
                                );
                            }
                        }
                    }
                }
            }
        
    }

    public static int getPack(){
        if (isPack.Contains("classic"))
                                return 0;
        if (isPack.Contains("halloween"))
                                return 1;
        if (isPack.Contains("christmas"))
                                return 2;
        if (isPack.Contains("cherry"))
                                return 3;
        return 0;
    }
    public static int getTile(string tag)
    {
        switch(tag){
        case ("12Sprite"):
            return 0;
        case ("13Sprite"):
            return 1;
        case ("14Sprite"):
            return 2;
        case ("15Sprite"):
            return 3;
        case ("16Sprite"):
            return 4; 
        case ("23Sprite"):
            return 5; 
        case ("24Sprite"):
            return 6; 
        case ("25Sprite"):
            return 7; 
        case ("26Sprite"):
            return 8; 
        case ("34Sprite"):
            return 9; 
        case ("35Sprite"):
            return 10; 
        case ("36Sprite"):
            return 11; 
        case ("45Sprite"):
            return 12; 
        case ("46Sprite"):
            return 13; 
        case ("56Sprite"):
            return 14; 
        case ("123Sprite"):
            return 15; 
        case ("124Sprite"):
            return 16; 
        case ("125Sprite"):
            return 17; 
        case ("126Sprite"):
            return 18; 
        case ("134Sprite"):
            return 19; 
        case ("135Sprite"):
            return 20; 
        case ("136Sprite"):
            return 21; 
        case ("145Sprite"):
            return 22; 
        case ("146Sprite"):
            return 23; 
        case ("156Sprite"):
            return 24; 
        case ("234Sprite"):
            return 25; 
        case ("235Sprite"):
            return 26; 
        case ("236Sprite"):
            return 27; 
        case ("245Sprite"):
            return 28; 
        case ("246Sprite"):
            return 29; 
        case ("256Sprite"):
            return 30; 
        case ("345Sprite"):
            return 31; 
        case ("346Sprite"):
            return 32; 
        case ("356Sprite"):
            return 33; 
        case ("456Sprite"):
            return 34; 
        case ("1234Sprite"):
            return 35; 
        case ("1235Sprite"):
            return 36; 
        case ("1236Sprite"):
            return 37; 
        case ("1256Sprite"):
            return 38; 
        case ("1345Sprite"):
            return 39; 
        case ("1346Sprite"):
            return 40; 
        case ("1356Sprite"):
            return 41; 
        case ("1456Sprite"):
            return 42; 
        case ("2345Sprite"):
            return 43; 
        case ("2346Sprite"):
            return 44; 
        case ("2356Sprite"):
            return 45; 
        case ("3456Sprite"):
            return 46; 
        case ("12345Sprite"):
            return 47; 
        case ("12346Sprite"):
            return 48; 
        case ("12356Sprite"):
            return 49; 
        case ("12456Sprite"):
            return 50; 
        case ("13456Sprite"):
            return 51; 
        case ("23456Sprite"):
            return 52; 
        default:
            return 0;
            
        }
    }
}
