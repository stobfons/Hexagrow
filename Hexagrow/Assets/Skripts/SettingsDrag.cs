using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class SettingsDrag
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
    private TileBase[] goalTiles;

    [SerializeField]
    private List<TileData> tileDatas;
    private Dictionary<TileBase, TileData> dataFromTiles;

    // Variables for Actions
    private bool placeable = false;
    TileBase targetTile;
    Vector3Int gridPosition;
    Transform parentAfterDrag; // set layer of object on the last
    private RectTransform rectTransform;
    private string dragTo = "goal";
    [SerializeField]
    public AudioClip _clip;

    // Update is called once per frame
    void Update()
    {
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
            if (nameTag.Contains(dragTo))
            {
                placeable = true;
            }
               
        } else  placeable = false;
        if (placeable)
        {
            Destroy(eventData.pointerEnter);
            SoundManager.Instance.PlaySound(_clip);
            Loader.cp = eventData.pointerEnter.name;
        } else eventData.pointerEnter.transform.position = eventData.pointerEnter.transform.parent.position; // Reset to Lap of Daddy (Parent Position)
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