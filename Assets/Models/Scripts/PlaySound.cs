using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
#if Editor
using UnityEditor;
#endif

public class PlaySound : MonoBehaviour {

	public AudioMixer mixer;
   public	AudioSource audioSource;
	Rigidbody rig;
	Explode explodeBall;

	public float _soundLevel;
	public float _normal;
	public float smothing=15;
	// Use this for initialization

	public AudioClip ground;
	public AudioClip hoop;
	public AudioClip spring;
	public AudioClip explode;


	void Start () {
		audioSource = GetComponent<AudioSource> ();
		rig = GetComponent<Rigidbody> ();
		explodeBall = GetComponent<Explode> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("ground")) {
			audioSource.clip=ground;
			_normal = Mathf.Abs (rig.velocity.y);
			
			_soundLevel = Mathf.Lerp ( -30f,0.5f,_normal/ smothing);
			
			//_soundLevel += 60f;
			//Debug.LogFormat("{0}v at {1} sound",rig.velocity.y,_soundLevel);
			mixer.SetFloat ("sfxVol",_soundLevel);
			//mixer.SetFloat ("EffectVolume", -19.14f);
			audioSource.Play ();
		}
		if (collider.gameObject.CompareTag("hoop") && rig.velocity.y<0&& !OneTime) {

			OneTime=false;
			audioSource.clip=hoop;

			//GameManager.Instatance().UpdateScore();
		

			_normal = Mathf.Abs (rig.velocity.y);
			
			_soundLevel = Mathf.Lerp ( -30f,0.5f,_normal/ smothing);
			
			//_soundLevel += 60f;
			//Debug.LogFormat("{0}v at {1} sound",rig.velocity.y,_soundLevel);
			mixer.SetFloat ("sfxVol",_soundLevel);
			audioSource.Play ();
		}
		if (collider.gameObject.CompareTag("spike")) {
			audioSource.clip=explode;
			audioSource.Play();
		
			explodeBall.ExplodeBall();
		}

		//Debug.Log ("sound");
	}
	public void OnTriggerStay(Collider collider)
	{
		if (collider.gameObject.CompareTag ("hoop") && rig.velocity.y < 0 ) {
			OneTime = true;
		}


	}
	public bool OneTime;
	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.CompareTag ("hoop") && rig.velocity.y < 0 ) {
			OneTime = false;
		}
		//OneTime = false;
		//mixer.SetFloat ("EffectVolume", -80f);
	}
}
