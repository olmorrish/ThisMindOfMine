using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public PlayerState playerState;
	public GameStateFlags gameState;
	bool spawned;

	// Use this for initialization
	void Start () {
		playerState = GetComponent<PlayerState>();
		gameState = GameObject.Find("GameState").GetComponent<GameStateFlags>();
		spawned = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(playerState.health < 1){
			spawned = false;
		}
		
		if(!spawned){
			
			Debug.Log("Player respawning.");
			
			if(gameState.lastRespawnPoint != null){
				gameObject.transform.position = gameState.lastRespawnPoint.transform.position;
				gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
				playerState.health = 3;
			}
			else{
				Debug.Log("FATAL ERROR: Player has nowhere to spawn!");
			}
			
			spawned = true;
		}
	}
}
