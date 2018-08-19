using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Make sure the 2D Collider has "Is Trigger" ticked!
*/
public class Sensor_ActiveOnShareSpace : MonoBehaviour {

	public GameObject sendsPulseTo = null;
	public bool sendContinuousSignal = false;	//defines how the sensor signals the object it is hooked up to
	
	private bool active;		//indicates if the trigger is activated
	private bool signalSent;	//indicates if a pulse has been sent already; used to stop signal if not continuous
	private Reciever antenna;

	// Use this for initialization
	void Awake () {
		active = false;
		signalSent = false;
		
		if(sendsPulseTo != null){
			antenna = sendsPulseTo.GetComponent<Reciever>();
		}			
	}
	
	void OnTriggerEnter2D(Collider2D col){
		active = true;
	}	
	void OnTriggerStay2D(Collider2D col){
		active = true;
	}	
	void OnTriggerExit2D(Collider2D col){
		active = false;
		signalSent = false;	//signalSent is just for each collision to prevent spamming the antenna
	}
	
	
	void Update(){
		
		if(sendsPulseTo != null){
			if(active && sendContinuousSignal){
				antenna.pulse = true;
			}
			
			else if(active && !signalSent){
				antenna.pulse = true;
				signalSent = true;
			}
		}
		
	}
}
