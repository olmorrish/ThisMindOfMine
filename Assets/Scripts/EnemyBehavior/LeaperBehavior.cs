using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaperBehavior : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator animator; 
	private SpriteRenderer rend;
	
	//public bool onGround = true;
	public bool onGround = true;
	public bool facingLeft = true;
	
	public Vector3 jumpVector = new Vector3(0,0,0);  
	public float jumpForce = 1f;
	
	// Use this for initialization
	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		rend = GetComponent<SpriteRenderer>();
		onGround = true;
		facingLeft = true;
	}
	
	// Update is called once per frame
	void Update() {

	}
	
	//jump windup, sets the jump animation going, which then calls Jump() as seen below
	public void JumpWindup() {
		animator.SetBool("woundUp", true);
	}
	
	//jump function, called by the animator 
	private void Jump() {
		rb.AddForce(jumpVector * jumpForce, ForceMode2D.Impulse);
		animator.SetBool("woundUp", false);
		animator.SetBool("onGround", false);
		animator.SetBool("flipping", false);
		onGround = false;
	}
	
	public void Land() {
		animator.SetBool("onGround", true);
	}
	
	public void FlipWindup(){
		animator.SetBool("flipping", true);
	}
	
	public void Flip() {
		//flip the jump vector so jump changes direction w/sprite
		Vector3 temp = jumpVector;
		temp.x *= -1;
		jumpVector = temp;
		
		facingLeft = !facingLeft;
		
		rend.flipX = !(rend.flipX);
	}
	
	public void FlipOff(){
		animator.SetBool("flipping", false);
	}
	
}
