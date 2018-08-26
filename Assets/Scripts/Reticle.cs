using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour {

	public GameObject Explosion;
	public GameObject ShotTrail;

	private GameObject Command;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;
		Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
		objPos.z = 0;

		this.transform.position = objPos;

		GameObject[] Commands = GameObject.FindGameObjectsWithTag("Command");
		
		float distance,work;
		work = 10000000;
		foreach(GameObject obj in Commands)
		{
			distance = Vector3.Distance(obj.transform.position, transform.position);
			if(distance < work)
			{
				Command = obj;
				work = distance;
			}
		}

		if (Input.GetMouseButtonDown(0))
		{
			Vector3 tmp = Command.transform.position;
			Instantiate(ShotTrail, new Vector3(tmp.x,tmp.y,tmp.z), Quaternion.identity);
		}
	}
}
