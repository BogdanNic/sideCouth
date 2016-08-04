using UnityEngine;
using System.Collections;

public class CameraF : MonoBehaviour {

	public GameObject player;
	public float maxHeight=2f;
	public float offesetX=1f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");


	}
	
	// Update is called once per frame
	void Update () {
//		if (isOn) {
//			transform.rotation = Quaternion.Lerp(rot, Quaternion.Euler(0,0,0), Time.time * 0.1f);
//		}

	}
	private Vector3 oldPos;
	private Quaternion rot;
	private bool isOn=false;
	void FixedUpdate()
	{
		transform.position = new Vector3 (player.transform.position.x+offesetX, maxHeight-1, transform.position.z);

		if (player.transform.position.y > maxHeight) {
		
			transform.LookAt (player.transform.position);
			rot=transform.rotation;
			isOn=true;
		} 
		else {
			transform.rotation=Quaternion.Euler(0f,0f,0f);
		}
	}
}
