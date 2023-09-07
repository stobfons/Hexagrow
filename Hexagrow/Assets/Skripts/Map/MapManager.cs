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

    private int[,] hexMap = new int[51,26];

    private Dictionary<TileBase, TileData> dataFromTiles;
    private string texturePack = "classic";
    public bool wasChanged = false;
    public string newPack = "classic";
    public static string isPack;

    public static bool checkNow = false;
    public static bool foundPath = false;

    public static int offset = 0;

    public void Start()
    {
        changeTextures();
        Vector3Int gridPosition = new Vector3Int(0, 0, 0);
        for (gridPosition.x = -25; gridPosition.x <= 25; gridPosition.x++)  {
            for (gridPosition.y = -25; gridPosition.y <= 0; gridPosition.y++) {
                if(map.GetTile(gridPosition)==null){
                    hexMap[gridPosition.x+25,gridPosition.y+25]=0;
                    //print("null");
                }else{
                    //print(dataFromTiles[map.GetTile(gridPosition)].nameTag);
                    if(dataFromTiles[map.GetTile(gridPosition)].nameTag.Contains("empty")){
                        hexMap[gridPosition.x+25,-gridPosition.y]=0;
                    }
                    if(dataFromTiles[map.GetTile(gridPosition)].nameTag.Contains("barrier")){
                        hexMap[gridPosition.x+25,-gridPosition.y]=0;
                        //print(gridPosition.x+25+" : "+(-gridPosition.y));
                    }
                    if(dataFromTiles[map.GetTile(gridPosition)].nameTag.Contains("start")){
                        hexMap[gridPosition.x+25,-gridPosition.y]=2;
                        //print(gridPosition.x+25+" : "+(gridPosition.y+25));
                    }
                    if(dataFromTiles[map.GetTile(gridPosition)].nameTag.Contains("goal")){
                        hexMap[gridPosition.x+25,-gridPosition.y]=3;
                        //print(gridPosition.x+25+" : "+(-gridPosition.y));
                    }
                }
                
                
            }
        }
        for (int x = 0; x<51; x++)  {
            for (int y = 0; y<26; y++) {
                //print(hexMap[x,y]);
                //if(hexMap[x,y]==3)print("Goal: "+x+" : "+y);
            }
        }
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
            //print("Changed MapManager");
            wasChanged = false;
            texturePack = newPack;
            isPack = texturePack;
            changeTextures();
        }
        if(checkNow){
            //checkPath();
            checkNow = false;
            checkPath();
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

    public void checkPath(){
        Vector3Int gridPosition = new Vector3Int(0, 0, 0);
        for (gridPosition.x = -25; gridPosition.x <= 25; gridPosition.x++)  {
            for (gridPosition.y = -25; gridPosition.y <= 0; gridPosition.y++) {
                //////// onDragEnd check for Path
                int x = gridPosition.x+25;
                int y = -gridPosition.y;
                if(map.GetTile(gridPosition)!=null){
                    string temp = dataFromTiles[map.GetTile(gridPosition)].nameTag;
                    if(temp.Contains("path"))
                        if(hexMap[x,y]==0){ // if not already found
                            hexMap[x,y]=1; // path = 1
                                           //print("1");
                            if (x>0 && x<50)
                            {
                                string num2 = "0";
                                int even = 1;
                                int ynum = 0;
                                int vecnum = 0;
                                if (gridPosition.y % 2 != 0) { even = 0; }
                                //print("even: "+even+" y pos: "+ y);
                                if (map.GetTile(gridPosition).name.Contains("1"))
                                {
                                    num2 = "4"; even = (even)*(-1);ynum = -1;vecnum = 1;
                                    //print("in 1 ist: "+even+"  "+vecnum);
                                    hexEditor(gridPosition.x, gridPosition.y, even, vecnum, num2, ynum);
                                }
                                if (map.GetTile(gridPosition).name.Contains("2"))
                                {
                                    if (gridPosition.y % 2 == 0) even = 0;
                                    else { even = 1; }
                                    print("even2: "+even);
                                    num2 = "5"; ynum = -1; vecnum = 1;
                                    hexEditor(gridPosition.x, gridPosition.y, even, vecnum, num2, ynum);
                                }
                                if (map.GetTile(gridPosition).name.Contains("3"))
                                {
                                    num2 = "6"; vecnum = 0; ynum = 0; even = 1;
                                    print("in 3 ist: " + even + "  " + vecnum);
                                    hexEditor(gridPosition.x, gridPosition.y, even, vecnum, num2, ynum);
                                }
                                if (map.GetTile(gridPosition).name.Contains("4")) 
                                {
                                    if (gridPosition.y % 2 == 0) even = 0;
                                    else{ even = 1; }
                                    num2 = "1";  ynum = 1; vecnum = -1;
                                    hexEditor(gridPosition.x, gridPosition.y, even, vecnum, num2, ynum);
                                }
                                if (map.GetTile(gridPosition).name.Contains("5"))
                                {
                                    //if (gridPosition.y % 2 == 0) even = -1;
                                    //else even = 0;
                                    num2 = "2";  ynum = 1; vecnum = -1;even *= (-1);
                                    hexEditor(gridPosition.x, gridPosition.y, even, vecnum, num2, ynum);
                                }
                                if (map.GetTile(gridPosition).name.Contains("6"))
                                {
                                    //print("check 6");
                                    num2 = "3";  ynum = 0; even = -1; vecnum = 0;
                                    hexEditor(gridPosition.x, gridPosition.y, even, vecnum, num2, ynum);
                                }
                                


                            }

                        } 
                }
            }
        }
        //print("Remaining Cards: "+((hexStack1.childCount+hexStack2.childCount+hexStack3.childCount)-1));
        if(foundPath){ 
            GameFinish.isFinish = true;
            

            }
        if(((hexStack1.childCount+hexStack2.childCount+hexStack3.childCount)<=1)&&!foundPath){
            print("is Over");
            GameOver.isOver = true;
        }
    }






    private void hexEditor(int x, int y,int even,int vecnum, string num2,int ynum)
    {
        int hexX = x+25 ;
        int hexY = y*(-1);
        int z = 0;
        if (hexMap[hexX, hexY] > 0)
        {
            Vector3Int tempPosition = new Vector3Int(x + even, y + vecnum, z);// Muss noch

            //print(" temppos.x: "+(tempPosition.x)+" temppos.y: "+(tempPosition.y));
            if (map.GetTile(tempPosition) != null)
            {
                if (hexMap[(hexX + even), (hexY + ynum)] == 2)
                {
                    //print("Try Connection from ("+hexMap[x,y]+")"+(gridPosition.x)+" : "+(gridPosition.y)+ " to: ("+hexMap[x-1,y]+")"+(gridPosition.x-1)+" : "+(gridPosition.y) );
                    if (map.GetTile(tempPosition).name.Contains(num2) || dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("start"))
                    {
                        if (hexMap[hexX , hexY ] == 3)
                        {
                            foundPath = true;
                            //print("finished game");
                        }
                        else hexMap[hexX, hexY] = 2;
                        print("connected to start");
                    }

                }
                if (hexMap[hexX + even, hexY + ynum] == 3)
                {
                    if (map.GetTile(tempPosition).name.Contains(num2) || dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("goal"))
                    {
                        if (hexMap[hexX , hexY ] == 2)
                        {
                            foundPath = true;
                        }
                        else hexMap[hexX, hexY] = 3;
                        print("connected to goal");
                    }
                }
            }
        }
    }


    void changeTextures()
    {
        Vector3Int gridPosition = new Vector3Int(0, 0, 0);
        string nameTag;
        int pack = 0;
            for (gridPosition.x = -26; gridPosition.x <= 26; gridPosition.x++)  { // remove Barrier Border x
            map.SetTile(new Vector3Int(gridPosition.x, 1, 0), null);
            map.SetTile(new Vector3Int(gridPosition.x, -26, 0), null);
            }
            for (gridPosition.y = -26; gridPosition.y <= 26; gridPosition.y++)  { // remove Barrier Border x
            map.SetTile(new Vector3Int(-26,gridPosition.y, 0), null);
            map.SetTile(new Vector3Int(26,gridPosition.y, 0), null);
            }
            for (gridPosition.x = -25; gridPosition.x <= 25; gridPosition.x++)  {
            for (gridPosition.y = -25; gridPosition.y <= 0; gridPosition.y++) {
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
                                map.SetTile(  gridPosition, pathTiles[getTile(map.GetTile(gridPosition).name) + (pack * 54)]
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
        print("Tag: "+tag);
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
        case ("2456Sprite"):
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
        case ("123456.2Sprite"):
            return 53;
        default:
            return 0;
            
        }
    }
}
/*
//print(map.GetTile(gridPosition).name);
if(x>0){
    if(map.GetTile(gridPosition).name.Contains("6") && hexMap[x,y]>0){
    //print("Contains 6");
        Vector3Int tempPosition = new Vector3Int(gridPosition.x-1,gridPosition.y,gridPosition.z);
        if(hexMap[x-1,y]==2){ 
        //print("Try Connection from ("+hexMap[x,y]+")"+(gridPosition.x)+" : "+(gridPosition.y)+ " to: ("+hexMap[x-1,y]+")"+(gridPosition.x-1)+" : "+(gridPosition.y) );
            if(map.GetTile(tempPosition).name.Contains("3")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("start")){
                if(hexMap[x-1,y]==3){
                    foundPath = true;
                }else hexMap[x,y]=2;
            //print("connected to start");
            }
        }
        if(hexMap[x-1,y]==3){
            if(map.GetTile(tempPosition).name.Contains("3")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("goal")){
                if(hexMap[x-1,y]==2){
                    foundPath = true;
                }else hexMap[x,y]=3;
            //print("connected to goal");
            }
        }
    }
}
    if(map.GetTile(gridPosition).name.Contains("1") && y>0 && hexMap[x,y]>0){
    //print("Contains 1");
        int even = 0;
        if(gridPosition.y%2==0)even=1;
            Vector3Int tempPosition = new Vector3Int(gridPosition.x-even,gridPosition.y+1,gridPosition.z);
            //print("Try Connection from ("+hexMap[x,y]+") "+(gridPosition.x)+" : "+(gridPosition.y)+ " to: ("+hexMap[x-even,y-1]+") "+(gridPosition.x-even)+" : "+(gridPosition.y+1) );
            //print("("+x+","+(y-1)+")");
        if(hexMap[x-even,y-1]==2){

            //print(dataFromTiles[map.GetTile(tempPosition)].nameTag); /////////
            if(map.GetTile(tempPosition).name.Contains("4")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("start")){
                hexMap[x,y]=2;
                if(hexMap[x-1,y]==3){
                    foundPath = true;
                }else hexMap[x,y]=2;
            //print("connected to start");
            }
        }
        if(hexMap[x-1,y-1]==3){
            if(map.GetTile(tempPosition).name.Contains("4")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("goal")){
                if(hexMap[x-1,y]==2){
                    foundPath = true;
                }else hexMap[x,y]=3;
            //print("connected to goal");
            }
        }
    }
if(map.GetTile(gridPosition).name.Contains("5") && y<25 && hexMap[x,y]>0){
    //print("Contains 5");
    int even = 0;
    if(gridPosition.y%2!=0)even=1;
    Vector3Int tempPosition = new Vector3Int(gridPosition.x-even,gridPosition.y+1,gridPosition.z);
    //print("Try Connection from ("+hexMap[x,y]+")"+(gridPosition.x)+" : "+(gridPosition.y) +" to: ("+hexMap[x-even,y+1]+")"+(gridPosition.x-even)+" : "+(gridPosition.y+1) );
    if(hexMap[x-even,y+1]==2){
        if(map.GetTile(tempPosition).name.Contains("2")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("start")){
            if(hexMap[x-even,y]==3){
                foundPath = true;
            }else hexMap[x,y]=2;
            //print("connected to start");
        }
    }
    if(hexMap[x-even,y+1]==3){
        if(map.GetTile(tempPosition).name.Contains("2")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("goal")){
            if(hexMap[x,y]==2){
                foundPath = true;
            }else hexMap[x,y]=3;
            //print("connected to goal");
        }
    }
}


if(x<50){
if(map.GetTile(gridPosition).name.Contains("3") && hexMap[x,y]>0){
    //print("Contains 3");
    Vector3Int tempPosition = new Vector3Int(gridPosition.x+1,gridPosition.y,gridPosition.z);
    //print("Try Connection from ("+hexMap[x,y]+")"+(gridPosition.x)+" : "+(gridPosition.y) +" to: ("+hexMap[x+1,y]+")"+(gridPosition.x+1)+" : "+(gridPosition.y) );
    if(hexMap[x+1,y]==2){
        if(map.GetTile(tempPosition).name.Contains("6")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("start")){
            if(hexMap[x,y]==3){
                foundPath = true;
            }else hexMap[x,y]=2;
            //print("connected to start");
        }
    }
    if(hexMap[x+1,y]==3){
        //print(dataFromTiles[map.GetTile(tempPosition)].nameTag);
        if(map.GetTile(tempPosition).name.Contains("6")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("goal")){
            //print("detected 3 to 6 or goal");
            if(hexMap[x,y]==2){
                foundPath = true;
            }else hexMap[x,y]=3;
            //print("connected to goal");
        }
    }
}
if(map.GetTile(gridPosition).name.Contains("2") && y>0 && hexMap[x,y]>0){
    //print("Contains 2");
    int even = 0;
    if(gridPosition.y%2!=0)even=1;
    Vector3Int tempPosition = new Vector3Int(gridPosition.x+even,gridPosition.y+1,gridPosition.z);
    //print("Try Connection from ("+hexMap[x,y]+")"+(gridPosition.x)+" : "+(gridPosition.y) +" to: ("+hexMap[x+even,y-1]+")"+(gridPosition.x+even)+" : "+(gridPosition.y+1) );
    if(hexMap[x+even,y-1]==2){
        if(map.GetTile(tempPosition).name.Contains("5")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("start")){
            if(hexMap[x,y]==3){
                foundPath = true;
            }else hexMap[x,y]=2;
            //print("connected to start, hexMap["+(x)+","+(y)+"] = "+hexMap[x,y]);
        }
    }
    if(hexMap[x+even,y-1]==3){
        if(map.GetTile(tempPosition).name.Contains("5")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("goal")){
            if(hexMap[x,y]==2){
                foundPath = true;
            }else hexMap[x,y]=3;
            //print("connected to goal");
        }
    }
}
    if(map.GetTile(gridPosition).name.Contains("4") && y<25 && hexMap[x,y]>0){
    //print("Contains 4");
        int even = 0;
        if(gridPosition.y%2!=0)even=1;
        //print(even);
        Vector3Int tempPosition = new Vector3Int(gridPosition.x+even,gridPosition.y-1,gridPosition.z);
    //print("Try Connection from ("+hexMap[x,y]+")"+(gridPosition.x)+" : "+(gridPosition.y) +" to: ("+hexMap[x+even,y+1]+")"+(gridPosition.x+even)+" : "+(gridPosition.y-1) );
        if(hexMap[x+even,y+1]==2){
            if(map.GetTile(tempPosition).name.Contains("1")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("start")){
                if(hexMap[x,y]==3){
                    foundPath = true;
                }else hexMap[x,y]=2;
            //print("connected to start");
            }
        }
        if(hexMap[x+even,y+1]==3){
            if(map.GetTile(tempPosition).name.Contains("1")||dataFromTiles[map.GetTile(tempPosition)].nameTag.Contains("goal")){
                if(hexMap[x,y]==2){
                    foundPath = true;
                }else hexMap[x,y]=3;
            //print("connected to goal");
            }
        }
    }
}
*/
