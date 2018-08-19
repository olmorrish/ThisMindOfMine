using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor_ActiveOnTouch : MonoBehaviour {

	public GameObject sendsPulseTo;
	public bool isHoldButton = true;

	public bool pulse;
	private bool collisionStay;

	private Reciever antenna;
	
	// Use this for initialization
	void Awake() {
		pulse = false; 
		collisionStay = false;
		antenna = sendsPulseTo.GetComponent<Reciever>();
	}
	
	void OnCollisionEnter2D(Collision2D col){
		pulse = true;
		collisionStay = true;
	}
	
	void OnCollisionExit2D(Collision2D col){
		if(isHoldButton){
			pulse = false;
		}
		collisionStay = false;
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if(pulse){
			antenna.pulse = true;
		}
	}
}
