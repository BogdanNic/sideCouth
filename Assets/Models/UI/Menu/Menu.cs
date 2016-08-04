using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	private Animator anim;
	private CanvasGroup canves;


	public bool IsOpen {
		get{
			return anim.GetBool("on");
		}
		set{
			anim.SetBool("on",value);
		
		}
	}	
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		canves = GetComponent<CanvasGroup> ();
		RectTransform rect = GetComponent<RectTransform> ();
		//rect.offsetMax = rect.offsetMin + new Vector2 (0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("on")) {
			canves.blocksRaycasts = canves.interactable = true;
		} else {
			canves.blocksRaycasts = canves.interactable = false;
		}
	}
}
