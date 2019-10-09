using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		
		//error flash animation trigger and disable
		spanim.SetBool("errorFlash", false);	    //otherwise it goes forever!
		
		if(spb.overlap && Input.GetButton("Spawn")){
			if((Input.GetButtonDown("Insec") && !insec.isSpawned) 
                || (Input.GetButtonDown("Anx") && !anx.isSpawned) 
                || (Input.GetButtonDown("Frust") && !frust.isSpawned)){
			
				spanim.SetBool("errorFlash", true);
			}
		}
	}
}


/*

	
	
			
		
		
		
		
		



*/