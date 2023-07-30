using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PathFollower : MonoBehaviour {

	public float speed = 2f;
	public string sceneName = "Menu";
	public static bool isChanging = false;
	public bool changeScene = false;
	public float timer = -1;
	public Transform pathParent;
	Transform targetPoint;
	int index;



	void OnDrawGizmos()
	{
		Vector2 from;
		Vector2 to;
		for (int a=0; a<pathParent.childCount; a++)
		{
			from = pathParent.GetChild(a).position;
			to = pathParent.GetChild((a+1) % pathParent.childCount).position;
			Gizmos.color = new Color (1, 0, 0); // rote Linie
			Gizmos.DrawLine (from, to);
		}
	}

	void Start () {
		index = 0;
		targetPoint = pathParent.GetChild (index);
		GameObject.Find("SaveManager").GetComponent<Loader>().loadNow();
		changeAudio.musicOf="Title";
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, targetPoint.position, speed * Time.deltaTime);
		if (Vector3.Distance (transform.position, targetPoint.position) < 0.1f) 
		{
			if(((timer>=0)&&(timer<=0.5)) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0) || isChanging)
				isChanging = true;
            	timer -=Time.deltaTime;
            	if ((timer) < 0) {
                	if(SoundManager.ready){
						print("Go to Menu");
                   		SoundManager.safetyVar=true;
                    	isChanging = false;
                    	SceneManager.LoadScene("Menu"); 
						changeAudio.musicOf="Menu";
						TexturepackManager.newSceneAudio = true;
						
            		}
        		}
		}
	}
}