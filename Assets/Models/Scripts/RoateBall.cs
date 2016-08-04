using UnityEngine;
using System.Collections;

public class RoateBall : MonoBehaviour {
	public Rigidbody rigitBody;
	public TouchPadBog touchPad;
	public bool useFullScreen=false;
	public float Rotation;
	// Use this for initialization
	void Start () {
		if (useFullScreen) {
			touchPad = GameObject.Find ("Pad").GetComponent<TouchPadBog>();
		}else{
			touchPad = GetComponent<TouchPadBog> ();
		}
		rigitBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (touchPad.GetDirection ()*Rotation*Time.deltaTime);
	}
	void FixedUpdate()
	{
		//Debug.Log(Quaternion.Euler(touchPad.GetDirection()*Rotation));
		//rigitBody.inertiaTensorRotation=Quaternion.Euler(touchPad.GetDirection()*Rotation);
		//transform.Rotate (touchPad.GetDirection ()*Rotation);

	}

}
