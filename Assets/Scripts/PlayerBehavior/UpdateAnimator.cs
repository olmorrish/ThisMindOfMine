using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAnimator : MonoBehaviour {

	private Rigidbody2D playerRB;
	private Animator animator;
	private PlayerState state;


	// Use this for initialization
	void Awake () {
		playerRB = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		state = GetComponent<PlayerState>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//////////////////////
		// Update the Animator
		//////////////////////
		
		animator.SetFloat("HorizontalVelocity", playerRB.velocity.x);
		animator.SetBool("Jumping", !(state.onGround));
	}
}
