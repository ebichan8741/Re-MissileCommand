using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTrail : MonoBehaviour {

	public float shot_speed;
	public GameObject Explosion;

	private Vector3 targetDir;
	private Vector3 targetPos;
	private GameObject Reticle;

	// Use this for initialization
	void Start () {
		Reticle = GameObject.FindGameObjectWithTag("Reticle");
		targetPos = Reticle.transform.position;
		targetDir = targetPos - transform.position;
		targetDir = targetDir.normalized;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().transform.Translate(targetDir * shot_speed, Space.World);
		float distance = Vector3.Distance(targetPos, transform.position);
		if(distance < 0.3f)
		{
			Destroy(gameObject);
			Vector3 tmp = transform.position;
			Instantiate(Explosion, new Vector3(tmp.x, tmp.y, tmp.z), Quaternion.identity);
		}
	}
}
