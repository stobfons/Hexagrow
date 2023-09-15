using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class DragAndDropToScene
    : MonoBehaviour,
        IPointerDownHandler,
        IBeginDragHandler,
        IDragHandler,
        IEndDragHandler
{
    /// Drag And Drop Variables
    // Information for Map
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

    // Variables for Actions
    private bool placeable = false;
    TileBase targetTile;
    Vector3Int gridPosition;
    Transform parentAfterDrag; // set layer of object on the last
    private RectTransform rectTransform;
    public string dragTo = "goal";
    public static string getDrag = "goal";
    public static string getScene = "goal";

    /// Additional Variables
    //public string sceneName = "0Example"; // next scene
    private static string nextScene = "Menu";
    public static bool isChanging = false;
    public static bool hasChanged = false;
    private float timer = 0.5f;
    [SerializeField]
    public AudioClip _clip;

    // Update is called once per frame
    void Update()
    {
        
            getScene = SceneManager.GetActiveScene().name;
        if (isChanging)
        {
            timer -=Time.deltaTime;
            if ((timer) < 0)
            {
                if(SoundManager.ready){
                    hasChanged=true;
                    isChanging = false;
                
                    if (nextScene.Contains("Exit"))
                    {
                        Loader.save();
                        Application.Quit();
                    }
                    if (nextScene.Contains("New"))
                    {
                        Loader.newGame();
                        SceneManager.LoadScene("Menu");

                    }
                    else
                    {
                    SceneManager.LoadScene(nextScene);
                    changeAudio.musicOf=nextScene;
                    TexturepackManager.newSceneAudio = true;
                    
                    }
                }
            }
        }
    }

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
            CameraFade.alpha = 1f;
            CameraFade.time = 0f;
            CameraFade.direction = 1;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gridPosition = map.WorldToCell(mousePosition);
        targetTile = map.GetTile(gridPosition);
        if (targetTile != null)
        {
            string nameTag = dataFromTiles[targetTile].nameTag;
            print(nameTag);
            if (nameTag.Contains(dragTo))
            {
                placeable = true;
            }
               
        } else  placeable = false;
        rectTransform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    
    {
        transform.SetParent(parentAfterDrag);
        if (targetTile != null)
        {
            string nameTag = dataFromTiles[targetTile].nameTag;
            print(nameTag);
            if (nameTag.Contains("goal"))
            {
                placeable = true;
            }
               
        } else  placeable = false;
        if (placeable)
        {
            map.SetTile(gridPosition, startTiles[MapManager.getPack()]);
            Destroy(eventData.pointerEnter);
            SoundManager.Instance.PlaySound(_clip);
            nextScene = eventData.pointerEnter.name;
            getDrag = nextScene;
            changeScene();
        } else eventData.pointerEnter.transform.position = eventData.pointerEnter.transform.parent.position; // Reset to Lap of Daddy (Parent Position)
    }

    private void changeScene()
    {
        if (CameraFade.alpha >= 1f) // Fully faded out
        {
            CameraFade.alpha = 1f;
            CameraFade.time = 0f;
            CameraFade.direction = 1;
        }
        else // Fully faded in
        {
            CameraFade.alpha = 0f;
            CameraFade.time = 1f;
            CameraFade.direction = -1;
        }
        
        isChanging = true;
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

    public void OnPointerDown(PointerEventData eventData) { }
}
