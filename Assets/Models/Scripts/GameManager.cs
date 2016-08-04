using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	private GameObject player;
	public Text text;
	public MenuManager manuM;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
