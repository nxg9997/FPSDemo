using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollisions : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name.Contains ("testTarget")) {
			Destroy (collision.gameObject);
			Debug.Log ("HIT!");
		}
		Destroy (gameObject);

	}
}
