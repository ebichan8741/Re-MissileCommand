using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//FadeManager.FadeIn();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Return))
		{
			//FadeManager.FadeOut(0);
			SceneManager.LoadScene("Title");
		}
	}
}
