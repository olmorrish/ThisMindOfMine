using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	public bool onGround;		 
	public bool jumpHeldDown;
	
	public int currentHealth;

	// Use this for initialization
	void Awake () {
		onGround = false;
		jumpHeldDown = false;
		currentHealth = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
