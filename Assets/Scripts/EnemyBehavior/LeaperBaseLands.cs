using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaperBaseLands : MonoBehaviour {

	private LeaperBehavior parentLeaper;
	private Animator animator;

	// Use this for initialization
	void Awake () {
		parentLeaper = transform.parent.GetComponent<LeaperBehavior>();
		animator = transform.parent.GetComponent<Animator>();
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		animator.SetBool("onGround", true);
		parentLeaper.Land();
		parentLeaper.onGround = true;
	}
}
