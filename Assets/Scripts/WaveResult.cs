using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveResult : MonoBehaviour {

	public Text text;

	public static int resultCityNum = 0;

	private int city_num = 0;
	private float time_s = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		time_s += Time.deltaTime;

		if (resultCityNum < city_num)
		{
			if (time_s >= 0.25f)
			{
				time_s = 0;
				resultCityNum++;
				FindObjectOfType<Score>().AddPoint(300);  // スコア加算
			}
		}
		text.text = resultCityNum.ToString();
	}

	public void SearchCityNum()
	{
		city_num = 0;
		foreach (GameObject obj in MissileGenerator.Cities)
		{
			if (obj.activeSelf)
			{
				city_num++;
			}
		}
	}

	public void CityCountReset()
	{
		resultCityNum = 0;
	}
}
