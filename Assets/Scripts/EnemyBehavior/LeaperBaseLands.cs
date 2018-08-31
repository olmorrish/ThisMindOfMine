using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaperBaseLands : MonoBehaviour {

	public LeaperBehavior parentLeaper;

	// Use this for initialization
	void Start () {
		parentLeaper = transform.parent.GetComponent<LeaperBehavior>();
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		parentLeaper.Land();
	}
}
