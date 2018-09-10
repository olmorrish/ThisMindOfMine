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
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("Player")){
			gameStateFlags.lastRespawnPoint = this.gameObject;
			Debug.Log("Setting respawn point to: " + gameObject.name);
		}
	}
	
	
	private void OnDrawGizmos(){
		Gizmos.color = new Color(1,0.2f,0,0.4f);
		Gizmos.DrawCube(transform.position, new Vector3(1.5f, 1.5f, 1));
	}
}
