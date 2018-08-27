using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresProjectile : MonoBehaviour {

	public int fireRate = 48;
	public int offset = 16;
	public GameObject projectile;
	private Vector3 spawnloc;
	public float spawnLocationOffset;

	// Use this for initialization
	void Start () {
		offset = 0;
		spawnloc = new Vector3(transform.position.x + spawnLocationOffset, transform.position.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		/*
		offset += 1;
		
		if(offset == fireRate){
			offset = 0;
			
			GameObject projectileClone = (GameObject) Instantiate(projectile, spawnloc, transform.rotation);
		}
		
		*/
		
	}
	
	void fire(){
		GameObject projectileClone = (GameObject) Instantiate(projectile, spawnloc, transform.rotation);
	}
	
	
	
	
	
	
}
