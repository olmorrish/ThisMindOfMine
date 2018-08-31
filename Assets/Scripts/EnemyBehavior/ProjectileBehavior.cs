using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

	public Animator animator;
	public float initialImpulse = 1f;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
		gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(initialImpulse, 0, 0), ForceMode2D.Impulse);
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		animator.SetBool("splat", true);
	}
	
	// Update is called once per frame
	void Update () {
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Projectile_Invisible")){
			Destroy(gameObject);
		}

	}
}
