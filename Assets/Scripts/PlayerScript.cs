using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	private Animator _animator;
	private CircleCollider2D _col;
	private SpriteRenderer _renderer;
	private bool flag = false;
	//destination point
	private Vector3 endPoint;
	//alter this to change the speed of the movement of player / gameobject
	public float Speed = 50.0f;
	//vertical position of the gameobject
	private float yAxis;
	// Use this for initialization
	void Start () {
		yAxis = gameObject.transform.position.y;
		_animator = gameObject.GetComponent<Animator> ();
		_col = gameObject.GetComponent<CircleCollider2D> ();
		_renderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//check if the screen is touched / clicked   
		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
		{
			//declare a variable of RaycastHit struct
			RaycastHit hit;
			//Create a Ray on the tapped / clicked position
			Ray ray;
			//for unity editor
			#if UNITY_EDITOR
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//for touch device
			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			#endif

			//Check if the ray hits any collider
			if(Physics.Raycast(ray,out hit))
			{
				//set a flag to indicate to move the gameobject
				flag = true;
				//save the click / tap position
				endPoint = hit.point;
				if (endPoint.x < gameObject.transform.position.x) 
				{
					_renderer.flipX = true;
				} else {
					_renderer.flipX = false;
				}
				//as we do not want to change the y axis value based on touch position, reset it to original y axis value
				endPoint.y = yAxis;
			}

		}
		//check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
		if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)){ //&& !(V3Equal(transform.position, endPoint))){
			//move the gameobject to the desired position
			_animator.SetBool("isWalking", true);
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1/(Speed*(Vector3.Distance(gameObject.transform.position, endPoint))));
		}
		//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) {
			_animator.SetBool("isWalking", false);
			flag = false;
		}


	}	

	void FlipHorizontal()
	{
		_animator.transform.Rotate(0, 180, 0);
	}


}
