using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public float explo_timelimit_s;
	public float collider_radius;

	private float time = 0;
	// Use this for initialization
	void Start () {
		CircleCollider2D collider = GetComponent<CircleCollider2D>();
		collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time >= explo_timelimit_s)
		{
			Destroy(gameObject);
		}
		CircleCollider2D collider = GetComponent<CircleCollider2D>();
		collider.radius = collider_radius * time;
		collider.enabled = true;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Missile")
		{
			Vector3 tmp = transform.position;
		}
	}
}
