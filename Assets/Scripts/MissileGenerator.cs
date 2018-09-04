﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour {

	public GameObject Missile;
	public float MinRangeX, MaxRangeX, MinRangeY, MaxRangeY, MinRotRange, MaxRotRange;
	public float CreateSpeed;

	public static int MissileCount;
	public static Vector3[] targetPos = new Vector3[9];

	private float time = 0;

	// Use this for initialization
	void Start () {
		MissileCount = 0;
		GameObject[] Cities = GameObject.FindGameObjectsWithTag("City");
		GameObject[] Commands = GameObject.FindGameObjectsWithTag("Command");

		int i = 0;
		for (; i < 6; i++)
		{
			targetPos[i] = Cities[i].transform.position;
			Debug.Log(targetPos[i]);
		}
		for (i = 0; i < 3; i++)
		{
			targetPos[i + 6] = Commands[i].transform.position;
			Debug.Log(targetPos[i]);
		}
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
		}
	}

}
