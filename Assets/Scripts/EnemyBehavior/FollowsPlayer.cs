using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowsPlayer : MonoBehaviour {

	private Rigidbody2D rb;
	
	private Vector2 rayDirection;
	private RaycastHit2D hit;
	
	private GameObject player;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		rayDirection = player.transform.position - transform.position;
		//origin, direction, distance, int layermask
		hit = Physics2D.Raycast (transform.position, rayDirection, 5f, 8);
		
		//origin, direction, distance, layermask, mindepth, maxdepth
		if (hit.collider != null) {
			Debug.Log("raycast hit " + hit.collider);

		}
	}
}
