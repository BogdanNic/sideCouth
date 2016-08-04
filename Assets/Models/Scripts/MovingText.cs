using UnityEngine;
using System.Collections;

public class MovingText : MonoBehaviour {

	public float speeed=5f;
	 Renderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		renderer.material. mainTextureOffset = new Vector2 (Time.time * speeed, 0f);
	}
}
