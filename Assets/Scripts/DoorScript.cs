using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{
	Animation animation;
	// Use this for initialization
	void Start () 
	{
		 animation = gameObject.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DoorOpen()
	{
		animation.Play("Open");
	}

	public void DoorClose()
	{
		animation.Play ("Close");
	}
}
