using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagesPlayer : MonoBehaviour {

	private Collider2D myHitbox;
	private Collider2D player;
	private PlayerState state;
	private Collider2D playerFeet;

	void Awake (){
		myHitbox = GetComponent<Collider2D>();
		player = GameObject.Find("Player").GetComponent<Collider2D>();
		state = GameObject.Find("Player").GetComponent<PlayerState>();
		playerFeet = GameObject.Find("Player_Feet").GetComponent<Collider2D>();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if((player.IsTouching(myHitbox)) || playerFeet.IsTouching(myHitbox)){
			
			if(!state.damageCooldownActive){	//player takes damage, cooldown is started
				state.health -= 1;
				state.damageCooldownActive = true;
			}

		}
	}
}
