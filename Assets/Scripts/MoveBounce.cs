using UnityEngine;
using System.Collections;

public class MoveBounce : MonoBehaviour {

	public Transform spring;
	public float scaleZ;
	public float Interm;
	public float d;
	public bool UseFullScreen=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate()
	{
		d = transform.gameObject.transform.position.y;
		d = d * ((d > 0) ? 1 : -1);
		Interm = Mathf.Lerp (25, 100, d/scaleZ);
		spring.localScale =new Vector3(spring.localScale.x, spring.localScale.y, Interm);


	}
}
