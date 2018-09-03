﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowsPlayer : MonoBehaviour {

	private Rigidbody2D rb;
	
	private Vector2 rayDirection;
	private RaycastHit2D hit;
	private Animator animator;
	
	private GameObject player;
	private Vector3 moveTo;
	public float travelForce = 1f;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.Find("Player");
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		moveTo = player.transform.position - transform.position;
		
		
		if(Vector3.Distance(player.transform.position, transform.position) < 5){
			
			animator.SetBool("isActive", true);
			
			
			rb.AddForce(moveTo * travelForce, ForceMode2D.Force);
			
			if(rb.velocity.y == 0f){
				if(player.transform.position.y > transform.position.y){
					rb.AddForce(new Vector3(0,5f,0), ForceMode2D.Force);
				}
				else{
					rb.AddForce(new Vector3(0,-5f,0), ForceMode2D.Force);
				}
				
			}
			
			if(rb.velocity.x == 0f){
				if(player.transform.position.x > transform.position.x){
					rb.AddForce(new Vector3(5f,0,0), ForceMode2D.Force);
				}
				else{
					rb.AddForce(new Vector3(-5f,0,0), ForceMode2D.Force);
				}
			}
		
		}
		
		else{
			animator.SetBool("isActive", false);
		}
		
		
	}
	
	
	
	
	bool canSeePlayer(){
		rayDirection = player.transform.position - transform.position;
		//origin, direction, distance, int layermask
		hit = Physics2D.Raycast (transform.position, rayDirection, 5f, 8);
		
		//origin, direction, distance, layermask, mindepth, maxdepth
		if (hit.collider != null) {
			Debug.Log("raycast hit " + hit.collider);

		}
		
		
		return true;
	}
}
