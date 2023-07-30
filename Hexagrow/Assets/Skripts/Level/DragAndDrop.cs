using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;

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

    private Dictionary<TileBase, TileData> dataFromTiles;

    Transform parentAfterDrag; // set layer of object on the last 
    
    private RectTransform rectTransform;

    private bool placeable = false;

    TileBase targetTile;
    Vector3Int gridPosition;
    [SerializeField]
    public AudioClip _clip;
    private GameObject hexClone;
    public static bool hasPath = false;
    public static bool joker = false;



    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();
        rectTransform = GetComponent<RectTransform>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }



    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gridPosition = map.WorldToCell(mousePosition); 
        targetTile = map.GetTile(gridPosition);
        if(targetTile!=null){
            string nameTag = dataFromTiles[targetTile].nameTag;
            //print(nameTag);
            if(nameTag.Contains("empty")){
                placeable=true;
            } else placeable = false;
        }else placeable = false;
        
        rectTransform.position = Input.mousePosition;
    }

public void OnEndDrag(PointerEventData eventData)
    {
        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gridPosition = map.WorldToCell(mousePosition); 
        targetTile = map.GetTile(gridPosition);
        transform.SetParent(parentAfterDrag);
        if(targetTile!=null){
            string nameTag = dataFromTiles[targetTile].nameTag;

            if(nameTag.Contains("empty")&&(Input.mousePosition.y>750f)){ ///Overlay ends around 700
                placeable=true;
            }
            if(eventData.pointerEnter.GetComponent<Unity.VectorGraphics.SVGImage>().sprite.name.Contains("Joker1")){
                    joker = true;
                    if(nameTag.Contains("barrier")&&(Input.mousePosition.y>750f)){ ///Overlay ends around 700
                         placeable=true;
                    } else placeable = false;
            }

        }else placeable = false;
        MapManager stacks = GameObject.Find("MapManager").GetComponent<MapManager>();
        
        if(placeable && joker==false){
            placeable = false;
            map.SetTile(gridPosition,pathTiles[MapManager.getTile(eventData.pointerEnter.GetComponent<Unity.VectorGraphics.SVGImage>().sprite.name)+(53*MapManager.getPack())]);
            Destroy(eventData.pointerEnter);
            SoundManager.Instance.PlaySound(_clip);
            hasPath = MapManager.checkPath(); ///////////////// checks for Path after Tile was Dropped
            print("Path was found?: "+hasPath); //////////// print check
        } else {
            eventData.pointerEnter.transform.position = eventData.pointerEnter.transform.parent.position; // Reset to Lap of Daddy (Parent Position) - aka SnapBack
        }
        if(placeable && joker){
            map.SetTile(gridPosition,emptyTiles[0]);
            joker = false;
            placeable = false;
            Destroy(eventData.pointerEnter);
            SoundManager.Instance.PlaySound(_clip);
        }
        ///////// after placed check
        if(((stacks.hexStack1.childCount+stacks.hexStack2.childCount+stacks.hexStack3.childCount)<=1)&&(!hasPath)){
                GameOver.isOver = true;
            } else {
                if (hasPath){
                    print("Game Finish");
                    GameOver.isOver = true;
                }
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




















// implements
public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

public void OnPointerDown(PointerEventData eventData)
    {
    }
}
