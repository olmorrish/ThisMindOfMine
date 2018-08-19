using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionWith : MonoBehaviour {

	public GameObject otherObjReference;
	
	private Collider2D theirHitBox;
	private Collider2D myHitBox;

	// Use this for initialization
	void Start () {
		
		theirHitBox = otherObjReference.GetComponent<Collider2D>();
		myHitBox = gameObject.GetComponent<Collider2D>();
		
		
		Physics2D.IgnoreCollision(myHitBox, theirHitBox);
	}

}
