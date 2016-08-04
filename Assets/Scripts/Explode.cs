using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	Renderer render;

	public bool hasExploded=false;
	//public AnimationCurve Curve1;
	//public Texture secondAlbedo;
	//public Texture  secondNormalMap;
	public Material mat;
	public SphereCollider sphereColliderPhics;
	public PhysicMaterial physicMat;
	private Rigidbody rig;
	private bool oneTime;
	//public Material mat;
	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody> ();
		render = GetComponent<Renderer> ();
		render.enabled = true;
		oneTime = true;
		//render.material.color = Color.blue;
		//render.material.mainTexture = Color.blue;
		//render.sharedMaterial = mat;
		//GetComponent<Renderer> ().sharedMaterial.SetTexture ("_DetailAlbedoMap", secondAlbedo);
		//GetComponent<Renderer> ().sharedMaterial.SetTexture("_DetailNormalMap",secondNormalMap);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (hasExploded&&oneTime) {
			//GetComponent<Renderer> ().sharedMaterial.SetTexture ("_DetailAlbedoMap", secondAlbedo);
			//GetComponent<Renderer> ().sharedMaterial.SetTexture("_DetailNormalMap",secondNormalMap);
			//transform.localScale=new Vector3(0.9f,0.9f,0.9f);
			//render.enabled=false;
			//render.enabled=true;
			//render.material.color=Color.blue;
			oldMat=render.sharedMaterial;
			oldPhysicMaterial=sphereColliderPhics.material;
			render.sharedMaterial =mat;
			sphereColliderPhics.material=physicMat;
			oneTime=false;
		}
	}
	public void ExplodeBall()
	{
		if (!hasExploded) {
			hasExploded = true;
			Vector3 d=rig.velocity;
			oldScale=transform.localScale;
			rig.AddForce(new Vector3(d.normalized.x,10f,d.normalized.z),ForceMode.Impulse);
			StartCoroutine(StartShrinking());
		}


		//MaterialPropertyBlock mat = new MaterialPropertyBlock ();
		//mat.SetTexture ("_DetailAlbedoMap", secondAlbedo);
		//mat.SetTexture ("_DetailNormalMap", secondNormalMap);
		//mat.SetTexture ("_AlbedoMap", secondNormalMap);
		//mat.Clear ();
		//GetComponent<Renderer> ().material.SetTexture ("_DetailAlbedoMap", secondAlbedo);
		//GetComponent<Renderer> ().SetPropertyBlock(mat);

	}
	public PhysicMaterial oldPhysicMaterial;
	public Material oldMat;
	public Vector3 oldScale;
	public void Reset()
	{
		if (oldMat!=null) {
			render.sharedMaterial = oldMat;
		}
		if (oldPhysicMaterial!=null) {
			sphereColliderPhics.material = oldPhysicMaterial;
		}

		if (transform.localScale!=Vector3.one) {
			transform.localScale = oldScale;
		}


	}
	IEnumerator StartShrinking()
	{
		for (int i = 0; i < 6; i++) {
			transform.localScale=transform.localScale-new Vector3(0.05f,0.05f,0.05f);
			yield	return  new WaitForSeconds (0.5f);
		}

	}
}
