﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Allows the object to be controlled via WASD and Spacebar
 * Controls and restricts player movement speed
 */
public class MoveWithWASD : MonoBehaviour {

	//customizable values
	public float jumpForce = 2f;
	public float continuousJumpForce = 0.7f;	    //force added by holding down the button
	public float continuousJumpDecay = 0.001f;
	public float horizontalForce = 12f;
	public float airControlDecay = 0.001f;
	public float maxHorizontalVelocity = 3f;
	
	private float maxContJumpForce;
	public float airControlMultiplier;

	private Rigidbody2D playerRB;
	private PlayerState state;

	
	// Use this for initialization
	void Awake () {	
		maxContJumpForce = continuousJumpForce;
		//onGround = false;
		//jumpHeldDown = false;
		playerRB = GetComponent<Rigidbody2D>();
		state = GetComponent<PlayerState>();
	}

	
	void Update () {
		
		///////////////////////////
		// Vertical Player Movement
		///////////////////////////

		if(Input.GetButton("Jump") || Input.GetKey("w") || Input.GetKey(KeyCode.Space)){	 
		
			//begin to jump condition
			if(state.onGround && playerRB.velocity.y > -0.01){
				playerRB.AddForce(new Vector3(0, 1.0f, 0) * jumpForce, ForceMode2D.Impulse);
				state.onGround = false;	
				state.jumpHeldDown = true;
			}
			
			//hold to jump higher
			else if(!state.onGround && state.jumpHeldDown){
				
				playerRB.AddForce(new Vector3(0, 1.0f, 0) * continuousJumpForce, ForceMode2D.Impulse);
				
				//update the continuous force being added by holding 
				if(continuousJumpForce<0){
					continuousJumpForce = 0;
					state.jumpHeldDown = false;	//disables the flag once it has no more effect
				}
				else if(continuousJumpForce>0){
					continuousJumpForce -= continuousJumpDecay;
				}
			}
			
			//otherwise the player is not on ground and jump should not held down
			else{
				state.jumpHeldDown = false;
			}
			
			//ensures falling players cannot jump
			if(playerRB.velocity.y < 0){
				state.jumpHeldDown = false;
			}

            //turns off the flag when the jump key isn't held down
            if ((!Input.GetKey("w") || !Input.GetButton("Jump")) && state.jumpHeldDown){
                state.jumpHeldDown = false;
            }

        }		
		
	
		/////////////////////////////
		// Horizontal Player Movement
		/////////////////////////////
        
		if((Input.GetAxis("Horizontal")>0 || Input.GetKey("d")) && !state.onGround){
			playerRB.AddForce((new Vector3(1, 0, 0)) * horizontalForce * airControlMultiplier, ForceMode2D.Force);
		}
		else if (Input.GetAxis("Horizontal") > 0 || Input.GetKey("d")){
			playerRB.AddForce((new Vector3(1, 0, 0)) * horizontalForce, ForceMode2D.Force);
		}
		if((Input.GetAxis("Horizontal")<0 || Input.GetKey("a")) && !state.onGround){
			playerRB.AddForce((new Vector3(-1, 0, 0)) * horizontalForce * airControlMultiplier, ForceMode2D.Force);
		}
		else if (Input.GetAxis("Horizontal") < 0 || Input.GetKey("a")){
			playerRB.AddForce((new Vector3(-1, 0, 0)) * horizontalForce, ForceMode2D.Force);
		}
		
		//update or reset airControlMultiplier
		if(state.onGround){
			airControlMultiplier = 1;
			continuousJumpForce = maxContJumpForce;
		}
		if(!state.onGround && airControlMultiplier>0){
			airControlMultiplier -= airControlDecay;
		}


		///////////////////////////////
		// Restrict Horizontal Velocity
		///////////////////////////////
		
		if(playerRB.velocity.x > maxHorizontalVelocity){
			playerRB.AddForce((new Vector3(-1,0,0)) * horizontalForce, ForceMode2D.Force);
		}
		
		if(playerRB.velocity.x < -maxHorizontalVelocity){
			playerRB.AddForce((new Vector3(1,0,0)) * horizontalForce, ForceMode2D.Force);
		}
	}
	
	
	
}
