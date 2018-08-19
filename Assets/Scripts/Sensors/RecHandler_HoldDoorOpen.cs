using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
So long as a pulse is being sent to the object, the door will be open
*/
public class RecHandler_HoldDoorOpen : MonoBehaviour {

	private Reciever rec;
	private Animator animator;

	// Use this for initialization
	void Awake () {
		rec = gameObject.GetComponent<Reciever>();
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
