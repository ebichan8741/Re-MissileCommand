using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour {

	public GameObject Missile;
	public float MinRangeX, MaxRangeX, MinRangeY, MaxRangeY, MinRotRange, MaxRotRange;
	public float CreateSpeed;
	public static int MissileCount;

	private float time = 0;

	// Use this for initialization
	void Start () {
		MissileCount = 0;
	}

	// Update is called once per frame
	void Update () {
		if (!WaveEmitter.isWaveStarted) {
			return;
		}

		time += Time.deltaTime;
		if (time >= CreateSpeed)
		{
			Vector3 missilePos = new Vector3(Random.Range(MinRangeX, MaxRangeX), Random.Range(MinRangeY, MaxRangeY), 0.0f);     // ミサイル生成座標

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
			MissileCount++;
			Debug.Log(MissileCount);
		}
	}

}
