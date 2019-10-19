using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * 
 */
public class FrustBlockPrimeHandler : MonoBehaviour {

	public bool primed = false;
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
		
        //update the animator
		if(primed){
			animator.SetBool("isPrimed", true);
		}
		
        //transformation ability
		if(Input.GetButton("Ability")){
			if(Input.GetButtonDown("Frust")){
				primed = true;
			}	
		}
		
        //de-prime the frsut block if it is ever despawned
		if(!state.isSpawned && primed){
			animator.SetBool("isPrimed", false);
			primed = false;
		}
	}
	
	//animator-called function to change the hitbox of the block
	void PrimeAndBig(){
		
		rb.mass = 20;
		hitbox.size = new Vector2(1, (22f/16f));
			
		temp = hitbox.offset;
		temp.y += (3f/16f);
		hitbox.offset = temp;
	}
	
	//animator-called function to change the hitbox of the block
	void PrimeAndSmall(){
		rb.mass = originalMass;
		hitbox.size = new Vector2(1, 1);
			
		temp = hitbox.offset;
		temp.y -= (3f/16f);
		hitbox.offset = temp;
	}
}
