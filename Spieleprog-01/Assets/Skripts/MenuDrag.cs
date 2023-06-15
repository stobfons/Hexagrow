using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class MenuDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Tilemap map;

    private Vector3 clickedTile;
    Transform parentAfterDrag;

    private RectTransform rectTransform;
    private Vector3Int dragpos;
    private Vector3Int goal;
    private Vector3 startPos;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        parentAfterDrag = transform.parent;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        clickedTile = map.CellToWorld(gridPosition);

        startPos = clickedTile;

        goal.x = Mathf.RoundToInt(4);
        goal.y = Mathf.RoundToInt(2);
        goal.z = Mathf.RoundToInt(0);

        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        dragpos = gridPosition;

        clickedTile = map.CellToWorld(gridPosition);
        print("AT 1st position " + gridPosition[0] + "AT 2nd position " + gridPosition[1] + "AT 3rd position " + gridPosition[2]);
        rectTransform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        if (dragpos == goal)
        {
            rectTransform.position = clickedTile;
            transform.SetParent(parentAfterDrag);
        }
        else
        {
            rectTransform.position = startPos;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
