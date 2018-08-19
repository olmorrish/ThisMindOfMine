using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithWASD : MonoBehaviour {

	
	public float jumpForce = 2f;
	public float continuousJumpForce = 0.7f;		//force added by holding down the button
	public float continuousJumpDecay = 0.001f;
	public float horizontalForce = 12f;
	public float airControlDecay = 0.001f;
	public float maxHorizontalVelocity = 2.5f;
	//public float maxJumpVelocity = 1f;
	
	private float maxContJumpForce;
	
	//position flags
	public bool onGround;		//TODO: fix ground hitbox detection 
	public bool jumpHeldDown;
	
	//
	private float airControlMultiplier;
	
	//collect other components
	Rigidbody2D playerRB;
	Animator animator;
	
	
	
	

	// Use this for initialization
	void Awake () {	
		maxContJumpForce = continuousJumpForce;
		onGround = false;
		jumpHeldDown = false;
		playerRB = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	

	
	
	
	void Update () {
		
		///////////////////////////
		// Vertical Player Movement
		///////////////////////////

		if(Input.GetKey("w")){
			
			//begin to jump condition
			if(onGround && playerRB.velocity.y > -0.01){
				playerRB.AddForce(new Vector3(0, 1.0f, 0) * jumpForce, ForceMode2D.Impulse);
				onGround = false;	
				jumpHeldDown = true;
			}
			
			//hold to jump higher
			else if(!onGround && jumpHeldDown){
				
				playerRB.AddForce(new Vector3(0, 1.0f, 0) * continuousJumpForce, ForceMode2D.Impulse);
				
				//update the continuous force being added by holding 
				if(continuousJumpForce<0){
					continuousJumpForce = 0;
					jumpHeldDown = false;	//disables the flag once it has no more effect
				}
				else if(continuousJumpForce>0){
					continuousJumpForce -= continuousJumpDecay;
				}
			}
			
			//otherwise the player is not on ground and jump should not held down
			else{
				jumpHeldDown = false;
			}
			
			//ensures falling players cannot jump
			if(playerRB.velocity.y < 0){
				jumpHeldDown = false;
			}
			
			
			
		}		
		
		
		
		/////////////////////////////
		// Horizontal Player Movement
		/////////////////////////////
		
		if(Input.GetKey("d") && !onGround){
			playerRB.AddForce((new Vector3(1, 0, 0)) * horizontalForce * airControlMultiplier, ForceMode2D.Force);
		}
		else if(Input.GetKey("d")){
			playerRB.AddForce((new Vector3(1, 0, 0)) * horizontalForce, ForceMode2D.Force);
		}
		if(Input.GetKey("a") && !onGround){
			playerRB.AddForce((new Vector3(-1, 0, 0)) * horizontalForce * airControlMultiplier, ForceMode2D.Force);
		}
		else if(Input.GetKey("a")){
			playerRB.AddForce((new Vector3(-1, 0, 0)) * horizontalForce, ForceMode2D.Force);
		}
		
		//update or reset airControlMultiplier
		if(onGround){
			airControlMultiplier = 1;
			continuousJumpForce = maxContJumpForce;
		}
		if(!onGround && airControlMultiplier>0){
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
		
		
		
		
		//////////////////////
		// Update the Animator
		//////////////////////
		
		animator.SetFloat("HorizontalVelocity", playerRB.velocity.x);
		animator.SetBool("Jumping", !onGround);
		
		

	}
	
	
	
}
