using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePosition : MonoBehaviour
{ 

    [SerializeField]
    private Tilemap map;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            Vector3 clickedTile = map.CellToWorld(gridPosition);
            
            transform.position = new Vector3((clickedTile[0]-2), clickedTile[1], clickedTile[2]);
            print("AT 1st position " + gridPosition[0]+ "AT 2nd position " + gridPosition[1]+ "AT 3rd position " + gridPosition[2]);

        }
    }
}
