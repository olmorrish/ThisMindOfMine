using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Updates the player and health animators based on the current player State variables
 */
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
		
		// update character animator
		animator.SetFloat("HorizontalVelocity", playerRB.velocity.x);
		animator.SetBool("Jumping", !(state.onGround));
		
        // update health animator
		healthAnimator.SetInteger("healthCount", state.health);
	}
}
