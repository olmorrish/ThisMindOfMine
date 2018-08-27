using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupBehavior : MonoBehaviour {

	private Collider2D player;
	private Collider2D hitbox;
	private Animator animator;
	private Animator backdropAnimator; 
	
	public int cooldownMax = 900;
	public int cooldown;
	bool onCD = false;
	
	private GameStateFlags gameState;
	private PlayerState playerState;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").GetComponent<Collider2D>();
		hitbox = GetComponent<Collider2D>();
		animator = GetComponent<Animator>();
		backdropAnimator = gameObject.transform.Find("TransparentBackdrop").GetComponent<Animator>();
		
		cooldown = 0;
		
		gameState = GameObject.Find("GameState").GetComponent<GameStateFlags>();
		playerState = GameObject.Find("Player").GetComponent<PlayerState>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(cooldown>0){
			cooldown -= 1;
		}
		
		else if(hitbox.IsTouching(player)){
			playerState.health = 3;
			hitbox.enabled = false;
			animator.SetBool("collected", true);
			backdropAnimator.SetBool("collected", true);
			
			cooldown = cooldownMax;
		}
		
		else{
			hitbox.enabled = true;
			animator.SetBool("collected", false);
			backdropAnimator.SetBool("collected", false);
		}
		
		
	}
}
