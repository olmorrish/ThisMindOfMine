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
				playerState.health = 3;
				spawned = true;
			}
			else{
				Debug.Log("FATAL ERROR: Player has nowhere to spawn!");
			}
		}
	}
}
