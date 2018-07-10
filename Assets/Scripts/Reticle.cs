using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour {

	public GameObject Explosion;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;
		Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
		objPos.z = 0;

		this.transform.position = objPos;

		if (Input.GetMouseButtonDown(0))
		{
			Vector3 tmp = transform.position;
			Instantiate(Explosion, new Vector3(tmp.x,tmp.y,tmp.z), Quaternion.identity);
			Debug.Log(tmp);
		}
	}
}
