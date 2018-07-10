using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour {

	public GameObject Missile;
	public float MinRangeX, MaxRangeX, MinRangeY, MaxRangeY, MinRotRange, MaxRotRange;
	public float CreateSpeed;

	private float time = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= CreateSpeed)
		{
			Instantiate(Missile, new Vector3(Random.Range(MinRangeX, MaxRangeX),
											 Random.Range(MinRangeY, MaxRangeY),
											 0),
										Quaternion.Euler(0,
														 0,
														 Random.Range(MinRotRange, MaxRotRange)));
			time = 0;
		}
	}
}
