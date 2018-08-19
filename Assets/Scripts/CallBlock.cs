using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBlock : MonoBehaviour {

	public GameObject blockToSpawn;
	public string callKey = "e";
	
	private bool inGame;
	
	// Use this for initialization
	void Awake () {
		inGame = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(callKey) && !inGame){
			Instantiate(blockToSpawn);
			inGame = true;
		}
	}
}
