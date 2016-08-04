using UnityEngine;
using System.Collections;

public class BallSpecifications : MonoBehaviour {

	public BallTest ball;
	public string nameBall="ball";
	public ParticleSystem particleSystemBall;
	private Rigidbody rig;
	// Use this for initialization
	void Start () {
		particleSystemBall = GetComponentInChildren<ParticleSystem> ();
		rig = GetComponent<Rigidbody> ();
		RefreshBall ();
#if Standalone
		transform.localScale=new Vector3(3f,3f,3f);
		rig.constraints= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
#endif
	

		//RigidbodyConstraints constraints=rig.constraints;

		//rig.constraints=RigidbodyConstraints.FreezePositionZ;
	}
	void OnLevelWasLoaded(int scene)
	{
	
		if (scene>0) {
			transform.localScale=new Vector3(1f,1f,1f);
			rig.constraints=RigidbodyConstraints.None;
			rig.constraints=RigidbodyConstraints.FreezePositionZ;
		}
	}
	public void RefreshBall()
	{
		particleSystemBall.Stop ();
		nameBall = ball.name;
		GetComponent<Renderer>().material=ball.mat;

		if (ball.useEffects) {
			particleSystemBall.startColor=ball.color;
			particleSystemBall.Play();

		} else {
			particleSystemBall.Stop();

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (ball.name!=nameBall) {
			RefreshBall();
		}
	}
}
