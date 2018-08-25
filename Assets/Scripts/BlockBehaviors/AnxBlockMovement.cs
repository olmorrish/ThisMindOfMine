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

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		state = GetComponent<BlockState>();
		//col = GetComponent<Collider2D>();
	}
	
	void OnCollisionEnter(){
		rb.velocity = Vector3.zero;
		uplock = false;
		downlock = false;
		rightlock = false;
		leftlock = false;
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if(state.isSpawned){
			if(Input.GetAxis("VerticalRS")>0){
				rb.velocity = Vector3.zero;
				uplock = true;
				downlock = false;
				rightlock = false;
				leftlock = false;
			}
			else if(Input.GetAxis("VerticalRS")<0){
				rb.velocity = Vector3.zero;
				uplock = false;
				downlock = true;
				rightlock = false;
				leftlock = false;
			}
			else if(Input.GetAxis("HorizontalRS")>0){
				rb.velocity = Vector3.zero;
				uplock = false;
				downlock = false;
				rightlock = true;
				leftlock = false;
			}
			else if(Input.GetAxis("HorizontalRS")<0){
				rb.velocity = Vector3.zero;
				uplock = false;
				downlock = false;
				rightlock = false;
				leftlock = true;
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
