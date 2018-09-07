using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveEmitter : MonoBehaviour {

	// Wave毎のミサイル数を格納する
	public int[] wavesToMisilleSporn;
	public static bool isWaveStart = false;
	public static bool isGameEnd = false;

	// Wave開始時のGUIプレハブを格納
	public GameObject WaveGUI;
	public GameObject WaveResultGUI;

	// 現在のWave
	public static int currentWave;

	private float time = 0;
	private bool isWaveEnd = false;

	IEnumerator Start()
	{
		isWaveStart = false;
		isWaveEnd = false;
		isGameEnd = false;

		// Waveが存在しなければコルーチンを終了する
		if (wavesToMisilleSporn.Length == 0)
		{
			yield break;
		}

		while (true)
		{
			// Waveが始まるまで待機
			while (!isWaveStart)
			{
				yield return new WaitForEndOfFrame();
			}

			// Waveのミサイル数が規定値になるまで待機
			while (wavesToMisilleSporn[currentWave] != MissileGenerator.MissileCount)
			{
				yield return new WaitForEndOfFrame();
			}

			isWaveStart = false;
			isWaveEnd = true;
			MissileGenerator.MissileCount = 0;

			// ボーナススコアを加算するまで待機
			while (isWaveEnd)
			{
				yield return new WaitForEndOfFrame();
			}

			// CityとCommandを復活させる
			SetActiveAll();

			// 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
			if (wavesToMisilleSporn.Length <= ++currentWave)
			{
				isGameEnd = true;
				currentWave = 0;
				yield break;
			}
		}
	}

	private void Update()
	{
		// Waveが始まるまでの処理
		if (!isWaveStart && !isWaveEnd && !isGameEnd)
		{
			time += Time.deltaTime;

			WaveGUI.SetActive(true);

			if(time >= 4)
			{
				WaveGUI.SetActive(false);
				isWaveStart = true;
				time = 0;
			}
		}

		// Waveが終わってからの処理
		if (isWaveEnd)
		{
			time += Time.deltaTime;

			if (time >= 7)
			{
				WaveResultGUI.SetActive(true);
				WaveResultGUI.GetComponent<WaveResult>().SearchCityNum();
			}

			if (time >= 11)
			{
				WaveResultGUI.SetActive(false);
				WaveResultGUI.GetComponent<WaveResult>().CityCountReset();
				time = 0;
				isWaveEnd = false;
			}
		}
		if (isGameEnd)
		{
			time += Time.deltaTime;
			if (time >= 2)
			{
				time = 0;
				SceneManager.LoadScene("Main");
			}
		}
	}

	void SetActiveAll()
	{
		GameObject[] CommandChild = new GameObject[10];
		int id = 0;

		// Commandを復活
		foreach (GameObject obj in MissileGenerator.Commands)
		{
			obj.SetActive(true);
			foreach (Transform transform in obj.transform)
			{
				// 子オブジェクトの取得
				CommandChild[id] = transform.gameObject;
				CommandChild[id].SetActive(true);
				id++;
			}
			id = 0;
		}

		// Cityを復活
		foreach (GameObject obj in MissileGenerator.Cities)
		{
			obj.SetActive(true);
		}
	}
}
