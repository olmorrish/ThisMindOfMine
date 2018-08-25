using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCollectableBehavior : MonoBehaviour {
	
	private Collider2D player;
	private Collider2D hitbox;
	private Animator animator;
	private Animator backdropAnimator; 
	
	private GameStateFlags gameState;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").GetComponent<Collider2D>();
		hitbox = GetComponent<Collider2D>();
		animator = GetComponent<Animator>();
		backdropAnimator = gameObject.transform.Find("TransparentBackdrop").GetComponent<Animator>();
		
		gameState = GameObject.Find("GameState").GetComponent<GameStateFlags>();
	}
	
	// Update is called once per frame
	void Update () {
		if(hitbox.IsTouching(player)){
			gameState.numMemories += 1;
			hitbox.enabled = false;
			animator.SetBool("collected", true);
			backdropAnimator.SetBool("collected", true);
		}
		
		
	}
}
