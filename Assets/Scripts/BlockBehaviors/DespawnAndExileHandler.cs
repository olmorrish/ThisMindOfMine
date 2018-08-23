using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAndExileHandler : MonoBehaviour {

	private Animator animator; 
	private BlockState state;
	private Collider2D col;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
		state = GetComponent<BlockState>();
		col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!state.exiled && !state.isSpawned){
			animator.SetBool("isSpawned", false);
		}
		
		//checks if the block can ACTUALLY be removed from gameplay
		//the ANIMATION MUST BE COMPLETE to do so!
		if (!state.exiled && !state.isSpawned && animator.GetCurrentAnimatorStateInfo(0).IsName(state.shortName + "_Invisible")){
			col.enabled = false;
			state.exiled = true; 
		}
		
		
		
		
		
		
	}
}
