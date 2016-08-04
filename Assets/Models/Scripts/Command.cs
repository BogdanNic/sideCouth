using UnityEngine;
using System.Collections;

public class Command : MonoBehaviour {

	public GameObject skate;
	private MoveSkate moveSkate;
	void Start()
	{
		moveSkate = skate.GetComponent<MoveSkate> ();
		if (moveSkate == null)
			Debug.Log ("skate null");
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("Player")) {
			moveSkate.StartRolling();
		}
	}

}
