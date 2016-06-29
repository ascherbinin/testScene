using UnityEngine;
using System.Collections;

public class SwitcherScript : MonoBehaviour 
{
	public DoorScript door;
	public GameObject _switchOn;
	public GameObject _switchOff;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") 
		{
			door.DoorOpen ();
			_switchOn.SetActive (true);
			_switchOff.SetActive (false);
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Player") 
		{
			_switchOn.SetActive (false);
			_switchOff.SetActive (true);
		}
	}
}
