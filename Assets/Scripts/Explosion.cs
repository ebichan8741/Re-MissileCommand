using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public float explo_time_s;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		explo_time_s -= Time.deltaTime;
		if(explo_time_s <= 0)
		{
			Destroy(gameObject);
		}
	}
}
