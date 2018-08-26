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
			GameObject[] Cities = GameObject.FindGameObjectsWithTag("City");

			int i = Random.Range(0, 5);
			Vector3 targetPos = Cities[i].transform.position;   // City1~6の間でランダムに選択
			Vector3 missilePos = new Vector3(Random.Range(MinRangeX, MaxRangeX), Random.Range(MinRangeY, MaxRangeY), 0.0f);     // ミサイル生成座標
			Vector3 targetDir = targetPos - missilePos;
			var rot = Quaternion.LookRotation(targetDir);
			rot.z = rot.z * Mathf.Rad2Deg;

			//Instantiate(Missile, new Vector3(Random.Range(MinRangeX, MaxRangeX),
			//								 Random.Range(MinRangeY, MaxRangeY),
			//								 0),
			//							Quaternion.Euler(0,
			//											 0,
			//											 Random.Range(MinRotRange, MaxRotRange)));
			Instantiate(Missile, missilePos,Quaternion.Euler(0,
															 0,
															 0));
			time = 0;
		}
	}
}
