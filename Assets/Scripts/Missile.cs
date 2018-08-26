using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	private Vector2 direction;
	private int targetCity;
	private Vector3 targetDir;

	public float explo_time_s;
	public float missile_speed;
	public GameObject Explosion;

	// Use this for initialization
	void Start () {
		//direction = transform.forward * 0.1f * missile_speed;
		GameObject[] Cities = GameObject.FindGameObjectsWithTag("City");
		targetCity = UnityEngine.Random.Range(0, 5);
		Vector3 targetPos = Cities[targetCity].transform.position;   // City1~6の間でランダムに選択
		targetDir = targetPos - transform.position;
		targetDir = targetDir.normalized;
		transform.rotation = Quaternion.FromToRotation(Vector3.left, targetDir);
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().transform.Translate(targetDir * missile_speed, Space.World);
		explo_time_s -= Time.deltaTime;
		if (explo_time_s <= 0 || transform.position.y < -5)
		{
			Destroy(gameObject);
		}

		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Explosion")
		{
			Destroy(gameObject);
			Vector3 tmp = transform.position;
			Instantiate(Explosion, new Vector3(tmp.x, tmp.y, tmp.z), Quaternion.identity);
		}

		if(collision.gameObject.tag == "Ground")
		{
			Destroy(gameObject);
			Vector3 tmp = transform.position;
			Instantiate(Explosion, new Vector3(tmp.x, tmp.y, tmp.z), Quaternion.identity);
		}

		if(collision.gameObject.tag == "City")
		{
			Destroy(gameObject);
			Vector3 tmp = transform.position;
			Instantiate(Explosion, new Vector3(tmp.x, tmp.y, tmp.z), Quaternion.identity);
		}
	}
}
