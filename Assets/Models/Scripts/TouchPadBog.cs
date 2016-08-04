using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class TouchPadBog : MonoBehaviour ,IPointerUpHandler,IPointerDownHandler,IDragHandler{

	public float smoothing;
	
	private Vector2 origin;
	private Vector2 direction;
	private Vector2 smoothDirection;
	private bool touched;
	private int pointerID;
	
	void Awake () {
		direction = Vector2.zero;
		touched = false;
	}
	
	public void OnPointerDown (PointerEventData data) {
		if (!touched) {
			touched = true;
			pointerID = data.pointerId;
			origin = data.position;
		}
	}
	
	public void OnDrag (PointerEventData data) {
		if (data.pointerId == pointerID) {
			Vector2 currentPosition = data.position;
			Vector2 directionRaw = currentPosition - origin;
			direction = directionRaw.normalized;
		//	Debug.Log(direction);
		}
	}
	
	public void OnPointerUp (PointerEventData data) {
		if (data.pointerId == pointerID) {
			direction = Vector3.zero;
			touched = false;
		}
	}
	
	public Vector3 GetDirection () {
		//smoothDirection = Vector3.MoveTowards (smoothDirection, direction, smoothing);
		//return smoothDirection;
		return direction*smoothing;
	}






	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




}
