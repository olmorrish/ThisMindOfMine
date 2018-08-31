using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Uses methods in LeaperBehavior
 */
public class LeaperAIController : MonoBehaviour {

	private GameObject player;
	private LeaperBehavior leaperBehavior;
	private SpriteRenderer rend;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find("Player");
		leaperBehavior = GetComponent<LeaperBehavior>();
		rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(leaperBehavior.onGround){
			//float dist = Vector3.Distance(player.transform.position.x < transform.position.x);
		
			//player to left condition 
			if((player.transform.position.x < transform.position.x)){
				if(!leaperBehavior.facingLeft){
					leaperBehavior.FlipWindup();
				}
				else{
					leaperBehavior.JumpWindup();
				}
			}
			
			//player to right condition 
			else if((player.transform.position.x > transform.position.x)){
				if(!leaperBehavior.facingLeft){
					leaperBehavior.JumpWindup();
				}
				else{
					leaperBehavior.FlipWindup();
				}
			}
		}
	}
}
