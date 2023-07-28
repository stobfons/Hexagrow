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

    private bool drag = false;

    

    private void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }


    private void LateUpdate(){
        if (Input.GetMouseButton(1)){
            Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if(drag == false)
            {
                drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

        } else {
            drag = false;
            if((xL > Camera.main.transform.position.x)){
                Difference = (Camera.main.ScreenToWorldPoint(new Vector3(xL,Camera.main.transform.position.y,0))) - Camera.main.transform.position;
                Camera.main.transform.position = Origin - Difference;
            }
            if((Camera.main.transform.position.x > xR)){
                //Debug.Log(Camera.main.transform.position.y);
                Difference = (Camera.main.ScreenToWorldPoint(new Vector3(xR,Camera.main.transform.position.y,0))) - Camera.main.transform.position;
                Camera.main.transform.position = Origin - Difference;
            }
            if((yD > Camera.main.transform.position.y)){
                Difference = (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x,yD,0))) - Camera.main.transform.position;
                Camera.main.transform.position = Origin - Difference;
            }
            if((Camera.main.transform.position.y > yU)){
                Difference = (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x,yU,0))) - Camera.main.transform.position;
                Camera.main.transform.position = Origin - Difference;
            }
        }

        if (drag && enableDrag){
                Camera.main.transform.position = Origin - Difference;
        }

        if (Input.GetMouseButton(2))
            Camera.main.transform.position = ResetCamera;

    }
}
