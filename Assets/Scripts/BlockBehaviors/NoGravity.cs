using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravity : MonoBehaviour {

	private Rigidbody2D blockRB;

	void Awake(){
		blockRB = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		blockRB.gravityScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
