using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAnimator : MonoBehaviour {

	private Rigidbody2D playerRB;
	private Animator animator;
	private PlayerState state;
	
	private Animator healthAnimator;

	// Use this for initialization
	void Awake () {
		playerRB = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		state = GetComponent<PlayerState>();
		
		healthAnimator = GameObject.Find("Health").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//////////////////////
		// Update the Animator
		//////////////////////
		
		animator.SetFloat("HorizontalVelocity", playerRB.velocity.x);
		animator.SetBool("Jumping", !(state.onGround));
		animator.SetBool("Grabbing", state.grabbing);
		
		healthAnimator.SetInteger("healthCount", state.health);
	}
}
