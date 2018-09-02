using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxReset : MonoBehaviour {
	
	private GameObject anx;
	private AnxBlockMovement mov;
	
	void Awake(){
		anx = GameObject.Find("Block2_Anxiety");
		mov = anx.GetComponent<AnxBlockMovement>();
	}
	
	void OnTriggerEnter2D(Collider2D col){
		
		if(!col.gameObject.tag.Equals("Skilift")){
			mov.ResetAnx();
		}
		
		
		
	}
	void OnTriggerStay2D(Collider2D col){
		if(!col.gameObject.tag.Equals("Skilift")){
			mov.ResetAnx();
		}
	}
	
	
	
	
    
	public void Down(){
		Vector3 v = anx.transform.position;
		v.y -= 2f/8f;
		transform.position = v;
	}
	
	public void Left(){
		Vector3 v = anx.transform.position;
		v.x -= 2f/8f;
		transform.position = v;
	}
	
	public void Right(){
		Vector3 v = anx.transform.position;
		v.x += 2f/8f;
		transform.position = v;
	}
	
	public void Up(){
		Vector3 v = anx.transform.position;
		v.y += 2f/8f;
		transform.position = v;
	}
	
	public void Center(){
		Vector3 v = anx.transform.position;
		transform.position = v;
	}
}
