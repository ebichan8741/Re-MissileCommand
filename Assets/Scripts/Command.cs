using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour {

	public GameObject Explosion;

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Explosion")
		{
			//Destroy(gameObject);
			gameObject.SetActive(false);
			Vector3 tmp = transform.position;
			Instantiate(Explosion, new Vector3(tmp.x, tmp.y, tmp.z), Quaternion.identity);
		}
	}
}
