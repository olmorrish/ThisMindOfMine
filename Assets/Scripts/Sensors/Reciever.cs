using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 The Reciever has a built in cooldown before a recieved pulse is no longer registered. 
*/
public class Reciever : MonoBehaviour {

	public bool pulse;
	public int pulseCooldownFrames = 2;
	
	private int cooldown;

	// Use this for initialization
	void Awake () {
		pulse = false;
		cooldown = pulseCooldownFrames;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(pulse == true){
			
			//tick down timer
			if(cooldown>0){
				cooldown -= 1;
			}
			
			else{
				cooldown = pulseCooldownFrames;	//reset
				pulse = false;
			}
			
		}
	}
}
