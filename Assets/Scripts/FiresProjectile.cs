using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresProjectile : MonoBehaviour {

	public int offset = 0;
	public GameObject projectile;
	private Vector3 spawnloc;
	public float spawnLocationOffset;
	private Animator animator;

	// Use this for initialization
	void Start () {
		spawnloc = new Vector3(transform.position.x + spawnLocationOffset, transform.position.y, 0);
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(offset>0){
			offset -= 1;
		}
		else{
			animator.SetBool("firing", true);
		}
		

		
	}
	
	void fire(){
		GameObject projectileClone = (GameObject) Instantiate(projectile, spawnloc, transform.rotation);
	}
	
	
	
	
	
	
}
