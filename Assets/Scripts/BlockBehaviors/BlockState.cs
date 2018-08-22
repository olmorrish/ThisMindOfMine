using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : MonoBehaviour { 
	
	public bool isSpawned = false;
	
	private Renderer renderer;
	private Collider2D collider;

	// Use this for initialization
	void Awake () {
		renderer = GetComponent<Renderer>();
		collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!isSpawned){
			renderer.enabled = false;
			collider.enabled = false;
			gameObject.transform.position = new Vector3(0,0,0);
		}
		else{
			renderer.enabled = true;
			collider.enabled = true;
			
		}
	}
}
