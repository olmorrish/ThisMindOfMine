using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxBlockMovement : MonoBehaviour {

	public float forceMultiplier;
	
	public bool uplock;
	public bool downlock;
	public bool rightlock;
	public bool leftlock;

	private Rigidbody2D rb;
	private BlockState state;
	//private Collider2D col;
	
	private AnxReset resetter;
	public bool canMove = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		state = GetComponent<BlockState>();
		resetter = GameObject.Find("AnxResetter").GetComponent<AnxReset>();
	}
	
	public void ResetAnx(){
		uplock = false;
		downlock = false;
		rightlock = false;
		leftlock = false;
		
		canMove = true;
	}

	
	// Update is called once per frame
	void Update () {
		
		if(!state.isSpawned){
			rb.velocity = Vector3.zero;
				uplock = false;
				downlock = false;
				rightlock = false;
				leftlock = false;
				
				canMove = true;
				resetter.Center();
		}
		
		if(state.isSpawned && canMove){
			if(Input.GetAxis("VerticalRS")>0){
				rb.velocity = Vector3.zero;
				uplock = true;
				downlock = false;
				rightlock = false;
				leftlock = false;
				
				canMove = false;
				resetter.Up();
			}
			else if(Input.GetAxis("VerticalRS")<0){
				rb.velocity = Vector3.zero;
				uplock = false;
				downlock = true;
				rightlock = false;
				leftlock = false;
				
				canMove = false;
				resetter.Down();
			}
			else if(Input.GetAxis("HorizontalRS")>0){
				rb.velocity = Vector3.zero;
				uplock = false;
				downlock = false;
				rightlock = true;
				leftlock = false;
				
				canMove = false;
				resetter.Right();
			}
			else if(Input.GetAxis("HorizontalRS")<0){
				rb.velocity = Vector3.zero;
				uplock = false;
				downlock = false;
				rightlock = false;
				leftlock = true;
				
				canMove = false;
				resetter.Left();
			}
		}
		
		
		
		
		
		if(uplock){				
			transform.Translate(new Vector3(0, 0.0008f, 0));								//required to bypass tilemap collision bug :/
			rb.AddForce((new Vector3(0, 1, 0)) * forceMultiplier, ForceMode2D.Force);
		}
		else if(downlock){
			transform.Translate(new Vector3(0, -0.0008f, 0));								//required to bypass tilemap collision bug :/ x2
			rb.AddForce((new Vector3(0, -1, 0)) * forceMultiplier, ForceMode2D.Force);
		}
		else if(rightlock){
			transform.Translate(new Vector3(0.0008f, 0, 0));								//required to bypass tilemap collision bug :/ x3
			rb.AddForce((new Vector3(1, 0, 0)) * forceMultiplier, ForceMode2D.Force);
		}
		else if(leftlock){
			transform.Translate(new Vector3(-0.0008f, 0, 0));								//required to bypass tilemap collision bug :/ x4
			rb.AddForce((new Vector3(-1, 0, 0)) * forceMultiplier, ForceMode2D.Force);
		}
		
		
		
	}
}
