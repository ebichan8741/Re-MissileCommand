using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	private Vector2 direction;

	public float explo_time_s;
	public float missile_speed;
	public GameObject Explosion;

	// Use this for initialization
	void Start () {
		direction = transform.up * -0.1f * missile_speed;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().transform.Translate(direction);
		explo_time_s -= Time.deltaTime;
		if (explo_time_s <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("ミサイルの方");
		if (collision.gameObject.tag == "Explosion")
		{
			Debug.Log("ミサイルの方");
			Destroy(gameObject);
			Vector3 tmp = transform.position;
			Instantiate(Explosion, new Vector3(tmp.x, tmp.y, tmp.z), Quaternion.identity);
		}
	}
}
