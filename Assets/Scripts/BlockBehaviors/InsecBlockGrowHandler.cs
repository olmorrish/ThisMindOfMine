using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsecBlockGrowHandler : MonoBehaviour {

	public bool big = false;
	public bool biggified = false; 	//flag to see if hitbox changes on growth have been applied
	private Vector2 temp;
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
		
		if(big && !biggified){
			animator.SetBool("isBig", true);
			
			rb.mass = 20;
			hitbox.size = new Vector2((30f/16f), (30f/16f));
			
			temp = hitbox.offset;
			temp.y += (7f/16f);
			hitbox.offset = temp;
			
			biggified = true;
		}
		
		//in process of despawning
		if(!state.isSpawned && big){

			hitbox.size = new Vector2((30f/16f), 0.01f);
			hitbox.offset = new Vector2(0, -(30f/32f));
			
			animator.SetBool("isBig", false);
			
			big = false;
			
		}
		
		//despawned
		if(state.exiled && biggified){
			rb.mass = originalMass;
			
			
			temp = hitbox.offset;
			temp.y -= (7f/16f);
			hitbox.offset = temp;
			
			
			hitbox.size = new Vector2(1,1);
			hitbox.offset = new Vector2(0, -(7f/16f));	//was changed if despawned while big
			
			biggified = false;
		}
		
		
		/////////////////
		//Button Handling
		/////////////////
		
		if(Input.GetButton("Ability")){
			
			if(Input.GetButtonDown("Insec")){
				big = true;
			}
			
			
		}
		
		
	}
}
