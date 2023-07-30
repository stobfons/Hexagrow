using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public bool enableDrag = true;
    public float xL = 10000;
    public int xR = 10000;
    public int yU = 10000;
    public int yD = 10000;

    private Vector3 Origin;
    private Vector3 Difference;
    private Vector3 ResetCamera;

    private bool isDragging = false;

    

    private void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }


    private void LateUpdate(){
        if (Input.GetMouseButton(1)){ // Right Button
            Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if(isDragging == false)
            {
                isDragging = true;  //Continue below else Case
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

        } else {
            isDragging = false;
            if((xL > Camera.main.transform.position.x)){
                print("out of left");
                //Camera.main.transform.position = new Vector3(xL,Camera.main.transform.position.y,0);
                //Camera.main.transform.position = Origin - Difference;
                Difference = new Vector3((Difference.x+xL), Difference.y, 0);
            }
            if((Camera.main.transform.position.x > xR)){
                print("out of right");
                //Debug.Log(Camera.main.transform.position.y);
                //Camera.main.transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(xR,Camera.main.transform.position.y,0)));
                //Camera.main.transform.position = Origin - Difference;
                Difference = new Vector3((Difference.x), (Difference.y+yU), 0);
            }
            if((yD > Camera.main.transform.position.y)){
                print("out of bottom");
                //Camera.main.transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x,yD,0)));
                //Camera.main.transform.position = Origin - Difference;
                Difference = new Vector3((Difference.x), (Difference.y+yD), 0);
            }
            if((Camera.main.transform.position.y > yU)){
                print("out of top");
                //Camera.main.transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x,yU,0)));
                //Camera.main.transform.position = Origin - Difference;
                Difference = new Vector3((Difference.x), (Difference.y-yU), 0);
            }
        }

        if (isDragging && enableDrag){ // is dragging & drag is allowed
                Camera.main.transform.position = Origin - Difference;
        }

        if (Input.GetMouseButton(2)) // Wheel
            Camera.main.transform.position = ResetCamera;

    }
}
