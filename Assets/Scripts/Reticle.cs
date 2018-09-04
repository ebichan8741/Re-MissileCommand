using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour {

	public GameObject Explosion;
	public GameObject ShotTrail;

	private GameObject Command;
	private GameObject[] CommandChild = new GameObject[10];

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// スクリーン座標をワールド座標に変換し、レティクルに適用
		Vector3 mousePos = Input.mousePosition;
		Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
		objPos.z = 0;
		this.transform.position = objPos;

		// レティクルに近いCommandsオブジェクトを検索
		GameObject[] Commands = GameObject.FindGameObjectsWithTag("Command");
		float distance,work;
		work = 10000000;
		foreach(GameObject obj in Commands)
		{
			distance = Vector3.Distance(obj.transform.position, transform.position);
			if(distance < work)
			{
				Command = obj;
				work = distance;
			}
		}

		int id = 0;
		foreach (Transform transform in Command.transform)
		{
			// Transformからゲームオブジェクト取得・削除
			CommandChild[id] = transform.gameObject;
			id++;
		}

		// Commandsの子オブジェクトのアクティブの数を取得
		int active_num = 0;
		for(int i = 0;i < 10; i++)
		{
			if (CommandChild[i].activeSelf == true)
			{
				active_num++;
			}
		}

		// 弾を撃つたびCommandsの子オブジェクトを一つ非アクティブ化させる
		if (Input.GetMouseButtonDown(0))
		{
			if(active_num > 0)	// アクティブの子オブジェクトが残っていれば撃てる
			{
				Vector3 tmp = Command.transform.position;
				Instantiate(ShotTrail, new Vector3(tmp.x, tmp.y, tmp.z), Quaternion.identity);
				for (int i = 9; i >= 0; i--)
				{
					if (CommandChild[i].activeSelf)
					{
						CommandChild[i].SetActive(false);
						break;
					}
				}
				active_num--;
			}
		}

		// Commandsの子オブジェクトのアクティブの数が０の時、Commandsオブジェクトを非アクティブ化
		if (active_num <= 0)
		{
			Command.SetActive(false);
			//Destroy(Command);
		}
	}
}
