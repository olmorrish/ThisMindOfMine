using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPreviewBehavior : MonoBehaviour {

	public bool isRight;
	
	private PlayerState state;

	// Use this for initialization
	void Awake () {
		isRight = true;
		state = GameObject.Find("Player").GetComponent<PlayerState>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("a") && isRight && state.onGround){
			gameObject.transform.Translate(-(23f/16f),0,0);
			isRight = false;
		}
		else if(Input.GetKey("d") && !isRight && state.onGround){
			gameObject.transform.Translate((23f/16f),0,0);
			isRight = true;
		}
	}
}
