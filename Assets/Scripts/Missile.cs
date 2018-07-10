using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	private Vector2 direction;
	public float explo_time_s;
	// Use this for initialization
	void Start () {
		direction = transform.up * -0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(transform.forward);
		GetComponent<Rigidbody2D>().transform.Translate(direction);
		explo_time_s -= Time.deltaTime;
		if (explo_time_s <= 0)
		{
			Destroy(gameObject);
		}
	}
}
