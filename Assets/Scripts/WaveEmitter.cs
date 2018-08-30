using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEmitter : MonoBehaviour {

	// Wave毎のミサイル数を格納する
	public int[] wavesToMisilleSporn;
	public static bool isWaveStarted;

	// Wave開始時のGUIプレハブを格納
	public GameObject WaveGUI;


	// 現在のWave
	private int currentWave;
	private float time = 0;

	IEnumerator Start()
	{
		// Waveが存在しなければコルーチンを終了する
		if (wavesToMisilleSporn.Length == 0)
		{
			yield break;
		}

		while (true)
		{
			//isWaveStarted = true;

			// 次waveまでの処理 //////////////////////////////////////////////////////
			isWaveStarted = false;
			MissileGenerator.MissileCount = 0;

			// Wave間の処理が終わるまで待機
			while (!isWaveStarted)
			{
				yield return new WaitForEndOfFrame();
			}
			////////////////////////////////////////////////////////////////////////

			// Waveのミサイル数が規定値になるまで待機
			while (wavesToMisilleSporn[currentWave] != MissileGenerator.MissileCount)
			{
				
				yield return new WaitForEndOfFrame();
			}
			
			// 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
			if (wavesToMisilleSporn.Length <= ++currentWave)
			{
				currentWave = 0;
			}
		}
	}

	private void Update()
	{
		if (!isWaveStarted)
		{
			//Instantiate(WaveGUI);
			WaveGUI.SetActive(true);

			time += Time.deltaTime;

			if(time >= 3)
			{
				//Destroy(WaveGUI);
				WaveGUI.SetActive(false);
				time = 0;
				isWaveStarted = true;
			}
		}
	}
}
