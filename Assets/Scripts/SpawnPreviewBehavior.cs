using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPreviewBehavior : MonoBehaviour {

	public bool isRight;
	public bool overlap; 
	
	private PlayerState state;
	//private Collider2D myHitbox; 
	
	private Collider2D levelHitbox; 

	// Use this for initialization
	void Awake () {
		isRight = true;
		state = GameObject.Find("Player").GetComponent<PlayerState>();
		//myHitbox = GetComponent<Collider2D>();
	}


	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal")<0 && isRight && state.onGround){
			gameObject.transform.Translate(-(23f/16f),0,0);
			isRight = false;
		}
		else if(Input.GetAxis("Horizontal")>0 && !isRight && state.onGround){
			gameObject.transform.Translate((23f/16f),0,0);
			isRight = true;
		}

		
	}
	
}
