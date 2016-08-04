using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
public class MoveSkate : MonoBehaviour {

	public Vector3 speed=new Vector3(0f,0f,0.01f);
	public Transform[] wheels;
	public float rotatingSpeed=10f;
	public bool start=false;
	public AudioSource source;
	public AudioMixer mixer;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		//StartRolling ();
	}
	
	// Update is called once per frame
	void Update () {


	}
	void FixedUpdate()
	{
		if (start) {
			for (int i = 0; i < wheels.Length; i++) {
				wheels[i].Rotate(new Vector3(rotatingSpeed,0f,0f));
			}
			transform.Translate (speed.x,speed.y,speed.z);;
		}
	}
	public void StopMoving()
	{
		start = false;
	}
	public void StartRolling()
	{
//		if (!source.isPlaying) {
//			source.Play ();
//		} else {
//			source.Stop();
//		}
		start = true;
		source.Play ();

	}
}
