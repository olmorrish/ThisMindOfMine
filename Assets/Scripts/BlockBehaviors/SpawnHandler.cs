using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour {

	private Vector3	temp;

	private Animator animator; 
	private BlockState state;
	private Collider2D col;
	private GameObject sp;
	private Rigidbody2D rb; 

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
		state = GetComponent<BlockState>();
		col = GetComponent<Collider2D>();
		rb = GetComponent<Rigidbody2D>();
		sp = GameObject.Find("SpawnPreview");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (state.exiled && state.isSpawned && animator.GetCurrentAnimatorStateInfo(0).IsName(state.shortName + "_Idle")){
			state.exiled = false; 
		}
		
		//alter the block on spawn-in
		if(state.isSpawned && !state.snappedToPreview){
			col.enabled = true;
			rb.velocity = Vector3.zero;
			gameObject.transform.position = sp.transform.position;
			
			//this is necessary since Insec block actually has a larger sprite size due to its ability!
			if(state.shortName.Equals("Insec")){
				temp = gameObject.transform.position;
				temp.y = temp.y + (7f/16f);
				gameObject.transform.position = temp;
			}
			
			state.snappedToPreview = true;
			animator.SetBool("isSpawned", true);
		}
		
		//if despawned, must reset the Location flag
		if(!state.isSpawned){
			state.snappedToPreview = false;
		}
	}
}
