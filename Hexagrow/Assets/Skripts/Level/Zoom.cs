using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public GameObject BG;
    public GameObject BGF;
    Vector3 BGS;
    Vector3 BGFS;
    public float maxZoom = 1.5f;

    void Start(){
        BGS = BG.gameObject.transform.localScale;
        BGFS = BGF.gameObject.transform.localScale;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
{
   
   Vector3 temp = BG.gameObject.transform.localScale;
   if((temp.x/1.1f)>BGS.x){
    Camera.main.orthographicSize /= 1.1f;
   temp.x /=1.1f; temp.y/=1.1f;
   BG.gameObject.transform.localScale = temp;
   temp = BGF.gameObject.transform.localScale;
   //temp.x /=1.1f; temp.y/=1.1f;
   BGF.gameObject.transform.localScale = temp;
   }

}
else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
{
   
   Vector3 temp = BG.gameObject.transform.localScale;
   if((temp.x*1.1f)<BGS.x*maxZoom){
   Camera.main.orthographicSize *= 1.1f;
   temp.x *=1.1f; temp.y*=1.1f;
   BG.gameObject.transform.localScale = temp;
   temp = BGF.gameObject.transform.localScale;
   //temp.x *=1.1f; temp.y*=1.1f;
   BGF.gameObject.transform.localScale = temp;
   }
}
    }
}
