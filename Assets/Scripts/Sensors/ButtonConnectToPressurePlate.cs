using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConnectToPressurePlate : MonoBehaviour {

	public Rigidbody2D plateReference;
	public SpringJoint2D spring; 

	// Use this for initialization
	void Start () {
		spring = GetComponent<SpringJoint2D>();
		
		
		plateReference = gameObject.transform.Find("PressurePlate").GetComponent<Rigidbody2D>();
		spring.connectedBody = plateReference;

		
		
		
	}
}
