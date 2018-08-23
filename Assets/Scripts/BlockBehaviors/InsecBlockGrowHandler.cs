using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsecBlockGrowHandler : MonoBehaviour {

	public bool big = false;
	private float originalMass; 
	private BoxCollider2D hitbox; 
	private Rigidbody2D rb; 
	private Animator animator;
	private BlockState state;

	// Use this for initialization
	void Start () {
		hitbox = GetComponent<BoxCollider2D>();
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		state = GetComponent<BlockState>();
		
		originalMass = rb.mass;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		/////////////////
		//Value Modifiers
		/////////////////
		
		if(big){
			animator.SetBool("isBig", true);
			
			rb.mass = 20;
			hitbox.size = new Vector2((30f/16f), (30f/16f));
		}
		
		if(!state.isSpawned && big){
			big = false;
			hitbox.size = new Vector2(0.01f,(30f/16f));
			animator.SetBool("isBig", false);
		}
		
		if(state.exiled){
			rb.mass = originalMass;
			hitbox.size = new Vector2(1,1);
		}
		
		
		/////////////////
		//Button Handling
		/////////////////
		
		if(Input.GetKey("q")){
			
			if(Input.GetKeyDown("1")){
				big = true;
			}
			
			
		}
		
		
	}
}
