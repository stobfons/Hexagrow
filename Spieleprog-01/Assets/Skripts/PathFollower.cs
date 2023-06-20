using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {

	public float speed = 2f;
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
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, targetPoint.position, speed * Time.deltaTime);
		if (Vector2.Distance (transform.position, targetPoint.position) < 0.1f) 
		{
			index++;
			index %= pathParent.childCount;
			targetPoint = pathParent.GetChild (index);
		}
	}
}