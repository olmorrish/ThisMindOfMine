using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollisionResetJump : MonoBehaviour {

	public GameObject playerObjReference;
	
	private MoveWithWASD wasd;
	
	
	void Start(){
		wasd = playerObjReference.GetComponent<MoveWithWASD>();
	}
	
	
	void OnCollisionEnter2D(Collision2D col){

		wasd.onGround = true;
		wasd.jumpHeldDown = false;
	}
	

	
}
