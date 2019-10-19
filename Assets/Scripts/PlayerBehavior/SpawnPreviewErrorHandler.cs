using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Checks block spawns status and collision on the spawner preview to see if error flash animation needs to play
 */
public class SpawnPreviewErrorHandler : MonoBehaviour {

	private BlockState insec;
	private BlockState anx;
	private BlockState frust;
	
	private SpawnPreviewBehavior spb;
	private Animator spanim;

	// Use this for initialization
	void Start () {
		insec = GameObject.Find("Block1_Insecurity").GetComponent<BlockState>();
		anx = GameObject.Find("Block2_Anxiety").GetComponent<BlockState>();
		frust = GameObject.Find("Block3_Frustration").GetComponent<BlockState>();
		
		spb = GetComponent<SpawnPreviewBehavior>();
		spanim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//error flash animation disable
		spanim.SetBool("errorFlash", false);

        //error flash animation triggers
        if(spb.overlap && (Input.GetButton("Spawn") || Input.GetKey("q"))){    //player must be holding down the spawn button; attempting to spawn

            if((Input.GetButtonDown("Insec") || Input.GetKeyDown("1")) && !insec.isSpawned){
                spanim.SetBool("errorFlash", true);
            }
            if ((Input.GetButtonDown("Anx") || Input.GetKeyDown("2")) && !anx.isSpawned){
                spanim.SetBool("errorFlash", true);
            }
            if ((Input.GetButtonDown("Frust") || Input.GetKeyDown("3")) && !frust.isSpawned){
                spanim.SetBool("errorFlash", true);
            }

        }




        /*
        if (spb.overlap && Input.GetButton("Spawn")){
			if(    (((Input.GetButtonDown("Insec") || Input.GetButtonDown("1")) && !insec.isSpawned)) 
                || (((Input.GetButtonDown("Anx") || Input.GetButtonDown("1")) && !anx.isSpawned))
                || (((Input.GetButtonDown("Frust") || Input.GetButtonDown("1")) && !frust.isSpawned)){
			
				spanim.SetBool("errorFlash", true);
			}
		}
        */
	}
}


/*

	
	
			
		
		
		
		
		



*/