using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{

	public float Speed = 50.0f;
	private bool flag = true;
	//destination point
	private Vector3 endPoint;
	//vertical position of the gameobject
	private float yAxis;
	// Use this for initialization
	public GameObject waypoint;
	void Start () 
	{
		yAxis = gameObject.transform.position.y;
		endPoint = waypoint.gameObject.transform.position;
		endPoint.y = yAxis;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		//check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
		if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)){ //&& !(V3Equal(transform.position, endPoint))){
			//move the gameobject to the desired position
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1/(Speed*(Vector3.Distance(gameObject.transform.position, endPoint))));
		}
		//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) {
			flag = false;
			Debug.Log("Enemy in place");
		}

	}
}
