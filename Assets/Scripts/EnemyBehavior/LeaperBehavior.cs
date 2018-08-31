using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaperBehavior : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator animator; 
	
	public bool toJump = false;
	public bool onGround = true;
	
	public Vector3 jumpVector = new Vector3(0,0,0);  
	public float jumpForce = 1f;
	
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		onGround = true;
		
		toJump = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		//TODO REMOVE
		if(toJump){
			JumpWindup();
			toJump = false;
		}
		
	}
	
	//jump windup, sets the jump animation going, which then calls Jump() as seen below
	public void JumpWindup(){
		animator.SetBool("onGround", false);
		Debug.Log("animator told that leaper is off the ground");
	}
	
	//jump function, called by the animator 
	private void Jump () {
		Debug.Log("Jump is being applied.");
		rb.AddForce(jumpVector * jumpForce, ForceMode2D.Impulse);
		//animator.SetBool("onGround", false);
		//Debug.Log("animator told that leaper is off the ground");
		onGround = false;
		Debug.Log("Leaper is off ground");
	}
	
	public void Land() {
		if(!onGround){
			Debug.Log("Leap() called and leaper, was on ground.");
			animator.SetBool("onGround", true);
			Debug.Log("animator told leaper is onGround.");
			onGround = true;
			Debug.Log("Leaper is on ground");
		}
	}
	
}
