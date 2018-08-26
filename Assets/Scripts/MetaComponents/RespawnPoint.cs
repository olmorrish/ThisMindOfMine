using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour {

	private Collider2D myCol; 
	private Collider2D playerCol;
	private GameStateFlags gameStateFlags;
	

	// Use this for initialization
	void Start () {
		myCol = gameObject.GetComponent<Collider2D>();
		playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
		gameStateFlags = GameObject.Find("GameState").GetComponent<GameStateFlags>();
	}
	
	// Update is called once per frame
	void Update () {
		if(myCol.IsTouching(playerCol)){
			gameStateFlags.lastRespawnPoint = this.gameObject;
		}
	}
}
