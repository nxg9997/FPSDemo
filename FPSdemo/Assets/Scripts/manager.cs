using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

	public Texture2D crosshair;
	public GameObject terrain;
	public GameObject target;
	public int targetNum;

	// Use this for initialization
	void Start () {
		TargetGen ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		GUI.DrawTexture( new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) /2, crosshair.width, crosshair.height), crosshair);
	}

	void TargetGen() {
		Vector3 dimentions;
		dimentions = terrain.GetComponent<Terrain> ().terrainData.size;
		for (int i = 0; i < targetNum; i++) {
			float rX = Random.Range (0, dimentions.x + 1);
			float rZ = Random.Range (0, dimentions.z + 1);
			GameObject newTarget = Instantiate (target, new Vector3 (rX, 2.5f, rZ), transform.rotation);
		}
	}
}
