using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecHandler_HoldOpenOrClosed : MonoBehaviour {

	private Reciever rec;
	private Animator animator;
	public bool invertBehavior = false;

	// Use this for initialization
	void Awake () {
		rec = gameObject.GetComponent<Reciever>();
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!invertBehavior){
			if(rec.pulse == true){
				//TODO: finish, only animation
				animator.SetBool("isLocked", false);
				GetComponent<Collider2D>().enabled = false;
			}
			
			else{
				animator.SetBool("isLocked", true);
				GetComponent<Collider2D>().enabled = true;
			}
		}
		
		else{
			if(rec.pulse == false){
				//TODO: finish, only animation
				animator.SetBool("isLocked", false);
				GetComponent<Collider2D>().enabled = false;
			}
			
			else{
				animator.SetBool("isLocked", true);
				GetComponent<Collider2D>().enabled = true;
			}

		}
		
		
		
	}
}
