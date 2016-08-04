using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Move : MonoBehaviour{

	public Rigidbody rigitBody;
	public TouchPadBog touchPad;
	public bool useFullScreen=false;
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

		rigitBody.AddForce (touchPad.GetDirection(),ForceMode.Impulse);


	}
}
