using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	public bool onGround;		 
	public bool jumpHeldDown;
	public bool grabbing;
	
	public int health = 3;
	public int damageCooldownFrames = 75;
	public int damageCooldownFramesRemaining;
	public bool damageCooldownActive;

	// Use this for initialization
	void Awake () {
		onGround = false;
		jumpHeldDown = false;
		grabbing = false;
		damageCooldownActive = false;
		damageCooldownFramesRemaining = damageCooldownFrames;
	}
	
	// Update is called once per frame
	void Update () {
		
		//cap player health
		if(health<0){
			health = 0;
		}
		
		//invulnerability frames
		if(damageCooldownActive){
			if(damageCooldownFramesRemaining > 0){
				damageCooldownFramesRemaining -= 1;
			}
			
			else{
				damageCooldownActive = false;
				damageCooldownFramesRemaining = damageCooldownFrames;
			}
		}
		
		//if damage has just been taken, throw the player upwards!
		if(damageCooldownFramesRemaining == damageCooldownFrames - 1){
			
			//horizontal knockback force
			float knockback = 3f;
			
			//if the player was moving right when colliding, set knockback to push player left
			if((GetComponent<Rigidbody2D>().velocity.x) > 0){
				knockback = -3f;
			}
				
			//apply a knockback with an upwards force
			GetComponent<Rigidbody2D>().AddForce(new Vector3(knockback, 2.0f, 0) * GetComponent<MoveWithWASD>().jumpForce, ForceMode2D.Impulse);
		
			//restrict midair movement
			onGround = false;
			GetComponent<MoveWithWASD>().airControlMultiplier = 0;
		}
	}
}
