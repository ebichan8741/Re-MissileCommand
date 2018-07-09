using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;
		Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
		objPos.z = 0;

		this.transform.position = objPos;
	}
}
