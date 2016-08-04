using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public Menu CurrentMenu;
	private GameObject player;
	private BallSpecifications ballSpecif;
	// Use this for initialization
	void Start () {

		ShowMenu (CurrentMenu);
		player = GameObject.FindGameObjectWithTag ("Player");
		DontDestroyOnLoad (player);
		ballSpecif = player.GetComponent<BallSpecifications> ();
	}
	

	public void ShowMenu (Menu menu)
	{
		if (CurrentMenu!=null) {
			CurrentMenu.IsOpen=false;
		}
		CurrentMenu = menu;
		CurrentMenu.IsOpen = true;

	}
	private AsyncOperation async;
	public void StartGame(int sceneId)
	{
		ShowMenu (CurrentMenu);
		Wait (2);
		if (sceneId == -1) {
			StartCoroutine(LoadLevelWithBar(1));
		} else {
			StartCoroutine(LoadLevelWithBar(sceneId));
		}
		
	}
	IEnumerator Wait (int seconds)
	{
		yield	return new  WaitForSeconds (2f);
		
	}
	IEnumerator LoadLevelWithBar (int level)
	{
		
		async = Application.LoadLevelAsync(level);
		//while (!async.isDone)
		//{
			//loadingBar.value = async.progress;
		//	yield return null;
		//}
		yield return null;
	}
	public void RestartLevel(int sceneId)
	{
		ResetPlayer(player);
		StartCoroutine(LoadLevelWithBar(sceneId));
	}

	void ResetPlayer (GameObject player)
	{
		player.transform.position = new Vector3 (0f, 2f, 0f);
		//player.transform.localScale = Vector3.one;
		Explode ballSpec = player.GetComponent<Explode> ();
		ballSpec.Reset ();
		Rigidbody rig = player.GetComponent<Rigidbody> ();
		rig.velocity = Vector3.zero;


	}

	public void ChangeSpecification(BallTest ball)
	{
		ballSpecif.ball = ball;
		ballSpecif.RefreshBall ();
	}
	public void CloseApp()
	{
		Application.Quit ();
	}
	public void Pause()
	{
		Time.timeScale = 0f;
	}
	public void Unpause()
	{
		Time.timeScale = 1f;
	}
}
