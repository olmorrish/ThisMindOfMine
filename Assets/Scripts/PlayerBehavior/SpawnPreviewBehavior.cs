using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Moves the spawn preview in key with player's current direction
 */
public class SpawnPreviewBehavior : MonoBehaviour {

	private bool isRight;
	public bool overlap; 
	
	private GameObject player;
	private PlayerState state;
	
	// Use this for initialization
	void Awake () {
		isRight = true;
		overlap = false;
		player = GameObject.Find("Player");
		state = player.GetComponent<PlayerState>();
	}

	
	void OnCollisionEnter2D(Collision2D col){
		overlap = true;
	}
	void OnCollisionStay2D(Collision2D col){
		overlap = true;
	}
	void OnCollisionExit2D(Collision2D col){
		overlap = false;
	}
	
	
	// Update is called once per frame
	void Update () {		

		if((Input.GetAxis("Horizontal")<0 || Input.GetKey("a")) && isRight && state.onGround){
			//gameObject.transform.Translate(-(23f/16f),0,0);
			isRight = false;
		}
		else if((Input.GetAxis("Horizontal")>0 || Input.GetKey("d")) && !isRight && state.onGround){
			//gameObject.transform.Translate((23f/16f),0,0);
			isRight = true;
		}

        /////////////////////
        // Movement Functions
        /////////////////////
		
		if(isRight){
			transform.position = new Vector3(player.transform.position.x + (11.5f/16f), player.transform.position.y + (3f/16f), 0);
		}
		else{
			transform.position = new Vector3(player.transform.position.x - (11.5f/16f), player.transform.position.y + + (3f/16f), 0);
		}

	}
	
}
