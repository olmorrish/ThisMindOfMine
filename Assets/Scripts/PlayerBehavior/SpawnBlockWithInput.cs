using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlockWithInput : MonoBehaviour {
	
	//spawn & despawn cooldown
	public int cooldownMax = 60;
	public int cooldown; 

	//get blockstates
	private BlockState insec;
	//private BlockState anx;
	//private BlockState frust;
	
	private Renderer spawnPreview;
	private PlayerState state;
	private Collider2D previewHitbox; 
	
	//for game progress permissions on spawning
	private GameStateFlags flags;
	
	// Use this for initialization
	void Start () {
		cooldown = cooldownMax;
		
		insec = GameObject.Find("Block1_Insecurity").GetComponent<BlockState>();
		//anx = GameObject.Find("Block2_Anxiety").GetComponent<BlockState>();
		//frust = GameObject.Find("Block3_Frustration").GetComponent<BlockState>();
		
		spawnPreview = GameObject.Find("SpawnPreview").GetComponent<Renderer>();
		state = GameObject.Find("Player").GetComponent<PlayerState>();
		previewHitbox = GameObject.Find("SpawnPreview").GetComponent<Collider2D>();
		
		flags = GameObject.Find("GameState").GetComponent<GameStateFlags>();
	}

	// Update is called once per frame
	void Update () {
		
		//cooldown update
		if(cooldown > 0){
			cooldown -= 1;
		}
		if(cooldown < 0){
			cooldown = 0;
		}
		
		///////////
		// SPAWN //
		///////////
		if(Input.GetButton("Spawn") && state.onGround && flags.canSpawnBlocks){
			
			spawnPreview.enabled = true;	//can see the preview 
			
			if(cooldown == 0){
				
				//spawn block1
				if(Input.GetButtonDown("Insec") && !Input.GetButton("Ability") && !insec.isSpawned && flags.hasInsec){
					insec.isSpawned = true;
					cooldown = cooldownMax;
				}

			}
		
			
		}
		else{
			spawnPreview.enabled = false;
		}
		
		/////////////
		// DESPAWN //
		/////////////
		if(Input.GetButtonDown("Insec") && !Input.GetButton("Ability") && insec.isSpawned && cooldown==0){
			insec.isSpawned = false;
			cooldown = cooldownMax;
		}
		
	}
}
