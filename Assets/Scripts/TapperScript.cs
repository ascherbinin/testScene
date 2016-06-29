using UnityEngine;
using System.Collections;

public class TapperScript : MonoBehaviour 
{
	private GameObject _innerImage;
	private Vector3 _startScale;
	private SpriteRenderer _renderer;
	private float _startAlpha;
	private Color _startColor;

	public float minSize;
	public float growFactor;
	public float waitTime;

	void Start()
	{
		_innerImage = GameObject.Find("image") as GameObject;
		_renderer = _innerImage.GetComponent<SpriteRenderer> () as SpriteRenderer;
		_startAlpha = _renderer.color.a;
		_startColor = _renderer.color;
	}

	IEnumerator Scale()
	{
		float timer = 0;
		float alpha = _startAlpha;

		while(true) // this could also be a condition indicating "alive or dead"
		{
			// we scale all axis, so they will have the same value, 
			// so we can work with a float instead of comparing vectors
			while(minSize < transform.localScale.x)
			{
				timer += Time.deltaTime;
				transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
				alpha += 0.01F;
				_renderer.color = new Color (_startColor.r, _startColor.g, _startColor.g, alpha);
				yield return null;
			}
			// reset the timer

			yield return new WaitForSeconds(waitTime);
		}
	}

	void Update()
	{
		if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown (0))) 
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);
			if (hit != null && hit.collider != null) {
				EventManager.TriggerEvent ("TapClick");
			}
		}
	}

	void Showing()
	{
		StartCoroutine(Scale());
	}

	void OnEnable () {
		//      EventManager.StartListening ("Spawn", spawnListener);
		EventManager.StartListening ("InPosition", Showing);
	}

	void OnDisable () {
		//      EventManager.StopListening ("Spawn", spawnListener);
		EventManager.StopListening ("InPosition", Showing);
	}

}
