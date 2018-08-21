using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	public bool onGround;		 
	public bool jumpHeldDown;
	public bool grabbing;
	
	public int currentHealth;

	// Use this for initialization
	void Awake () {
		onGround = false;
		jumpHeldDown = false;
		grabbing = false;
		currentHealth = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
