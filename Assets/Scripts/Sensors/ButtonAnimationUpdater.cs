using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationUpdater : MonoBehaviour {

	private Animator animator;
	private Sensor_ActiveOnTouch sensor;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
		sensor = GetComponent<Sensor_ActiveOnTouch>();
		
	}
	
	void Start(){
		if(sensor.isHoldButton){
			animator.SetBool("isHoldButton", true);
		}
		else{
			animator.SetBool("isHoldButton", false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(sensor.pulse){
			animator.SetBool("Pressed", true);
		}
		else{
			animator.SetBool("Pressed", false);
		}
		
	}
}
