using UnityEngine;
using System.Collections;

public class SpringBounceForceTrigger : MonoBehaviour {

	public SpringJoint spring;

	// Use this for initialization
	void Start () {


	}
	

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("spring")) {
			spring.spring = 100;
			StartCoroutine(ReturnToForce());
		}

	}
	IEnumerator ReturnToForce()
	{
		yield return new WaitForSeconds (1f);
		spring.spring = 12;
	
	}
	void OnTriggerExit(Collider collider)
	{
		//spring.spring = 10;
	}
}
