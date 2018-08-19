using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecHandler_Float : MonoBehaviour {

	private Reciever rec;

	// Use this for initialization
	void Awake () {
		rec = gameObject.GetComponent<Reciever>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(rec.pulse == true){
			gameObject.transform.Translate(0,0.02f,0);
		}
		
	}
}
