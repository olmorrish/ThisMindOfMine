using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 The Reciever has a built in cooldown before a recieved pulse is no longer registered. 
*/
public class Reciever : MonoBehaviour {

	public bool pulse;
	
	// Use this for initialization
	void Awake () {
		pulse = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
