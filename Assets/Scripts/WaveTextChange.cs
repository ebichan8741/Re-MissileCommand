using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTextChange : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int wave = WaveEmitter.currentWave + 1;
		text.text = "WAVE " + wave;
	}
}
