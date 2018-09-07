using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour {

	int resultScore = 0;

	// Use this for initialization
	void Start () {
		resultScore = Score.GetScore();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text = resultScore.ToString();
	}
}
