using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

	public GameObject bullet;
	public GameObject fpc;
	public int bulletSpeed;
	public AudioClip fired;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Shoot ();
	}

	void Shoot(){
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			Debug.Log ("Shot");
			AudioSource.PlayClipAtPoint (fired, fpc.transform.position);
			GameObject projectile = Instantiate (bullet, new Vector3(fpc.transform.position.x, fpc.transform.position.y, fpc.transform.position.z), fpc.transform.rotation) as GameObject;
			projectile.transform.rotation = new Quaternion (fpc.transform.rotation.x, 90, fpc.transform.rotation.z, fpc.transform.rotation.w);

			projectile.GetComponent<Rigidbody> ().AddForce (fpc.transform.forward * bulletSpeed);
			//bullet.GetComponent<Rigidbody> ().velocity = new Vector3 (10, 0, 0);

		}
	}
}
