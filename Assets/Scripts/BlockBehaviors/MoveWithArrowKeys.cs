using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithArrowKeys : MonoBehaviour {

	/*

	//customizable values
	public float acceleration = 12f;
	public float maxVelocity = 3f;

	private Rigidbody2D blockRB;
	private PlayerState state;

	// Use this for initialization
	void Awake () {	
		blockRB = GetComponent<Rigidbody2D>();
	}

	void Update () {
		
		///////////////////////////
		// Vertical Player Movement
		///////////////////////////

		
		
		if(Input.GetKey("d") && !state.onGround){
			blockRB.AddForce((new Vector3(1, 0, 0)) * horizontalForce * airControlMultiplier, ForceMode2D.Force);
		}
		else if(Input.GetKey("d")){
			blockRB.AddForce((new Vector3(1, 0, 0)) * horizontalForce, ForceMode2D.Force);
		}
		if(Input.GetKey("a") && !state.onGround){
			blockRB.AddForce((new Vector3(-1, 0, 0)) * horizontalForce * airControlMultiplier, ForceMode2D.Force);
		}
		else if(Input.GetKey("a")){
			blockRB.AddForce((new Vector3(-1, 0, 0)) * horizontalForce, ForceMode2D.Force);
		}
		

		
		//////////////////////////////////////////
		// Restrict Horizontal & Veritcal Velocity
		//////////////////////////////////////////
		
		if(blockRB.velocity.x > maxHorizontalVelocity){
			blockRB.AddForce((new Vector3(-1,0,0)) * horizontalForce, ForceMode2D.Force);
		}
		
		if(blockRB.velocity.x < -maxHorizontalVelocity){
			blockRB.AddForce((new Vector3(1,0,0)) * horizontalForce, ForceMode2D.Force);
		}
	}
	
	
	*/
}
