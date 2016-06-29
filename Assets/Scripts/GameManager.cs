using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	void OnEnable () {
		//      EventManager.StartListening ("Spawn", spawnListener);
		EventManager.StartListening ("TapClick", TapClick);
	}

	void OnDisable () {
		//      EventManager.StopListening ("Spawn", spawnListener);
		EventManager.StopListening ("TapClick", TapClick);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void TapClick()
	{
		Debug.Log ("TAPCLICK!!!");
	}
}
