using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Input handler for all player attempts to spawn blocks
 */
public class SpawnBlockWithInput : MonoBehaviour {
	
	//spawn & despawn cooldown
	public int cooldownMax = 60;
	public int cooldown; 

	//get blockstates
	private BlockState insec;
	private BlockState anx;
	private BlockState frust;
	
	private GameObject spawnPreview;
	private SpawnPreviewBehavior spBehaviorScript;
	private Renderer spPreviewRend;
	private PlayerState state;
	private Collider2D previewHitbox; 
	
	//for game progress permissions on spawning
	private GameStateFlags flags;
	
	// Use this for initialization
	void Start () {
		cooldown = cooldownMax;
		
		insec = GameObject.Find("Block1_Insecurity").GetComponent<BlockState>();
		anx = GameObject.Find("Block2_Anxiety").GetComponent<BlockState>();
		frust = GameObject.Find("Block3_Frustration").GetComponent<BlockState>();
		
		spawnPreview = GameObject.Find("SpawnPreview");
		spBehaviorScript = spawnPreview.GetComponent<SpawnPreviewBehavior>();
		spPreviewRend = spawnPreview.GetComponent<Renderer>();
		state = GameObject.Find("Player").GetComponent<PlayerState>();
		previewHitbox = spawnPreview.GetComponent<Collider2D>();
		
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
        if ((Input.GetButton("Spawn") || Input.GetKey("e")) && state.onGround && flags.canSpawnBlocks) {

            //button is held down, so player can see the Spawn Preview of where the block will spawn
            spPreviewRend.enabled = true;   

            if (cooldown == 0 && !spBehaviorScript.overlap) {

                //each block checks that their secondary ability key is not also held down (q or right bumper)
                //spawn block1
                if ((Input.GetButtonDown("Insec") && !Input.GetButton("Ability")) 
                    || (Input.GetKeyDown("1") && !Input.GetKey("q"))){

                    if (!insec.isSpawned && insec.exiled && flags.hasInsec) {
                        insec.isSpawned = true;
                        cooldown = cooldownMax;
                    }
				}
				
				//spawn block2
				if ((Input.GetButtonDown("Anx") && !Input.GetButton("Ability")) 
                    || (Input.GetKeyDown("2") && !Input.GetKey("q"))){

                    if (!anx.isSpawned && anx.exiled && flags.hasAnx) {
                        anx.isSpawned = true;
                        cooldown = cooldownMax;
                    }
				}

                //spawn block3
                if (((Input.GetButtonDown("Frust") && !Input.GetButton("Ability"))
                    || (Input.GetKeyDown("3") && !Input.GetKey("q")))){

                    if (!frust.isSpawned && frust.exiled && flags.hasFrust) {

                        frust.isSpawned = true;
                        cooldown = cooldownMax;
                    }
                }

			}

		}
		else{
			spPreviewRend.enabled = false;  //diappears if button is not held down
		}
		
		/////////////
		// DESPAWN //
		/////////////
		
		if(cooldown==0){
			
			if((Input.GetButtonDown("Insec") && !Input.GetButton("Ability")) 
                || (Input.GetKeyDown("1") && !Input.GetKey("q")) 
                && insec.isSpawned){

                insec.isSpawned = false;
			    cooldown = cooldownMax;
			}
			
			if((Input.GetButtonDown("Anx") && !Input.GetButton("Ability"))
                || (Input.GetKeyDown("2") && !Input.GetKey("q"))
                && anx.isSpawned){

                anx.isSpawned = false;
				cooldown = cooldownMax;
			}
			
			if((Input.GetButtonDown("Frust") && !Input.GetButton("Ability"))
                || (Input.GetKeyDown("3") && !Input.GetKey("q"))
                && frust.isSpawned){

				frust.isSpawned = false;
				cooldown = cooldownMax;
			}
		}
		
		
		
	}
}
