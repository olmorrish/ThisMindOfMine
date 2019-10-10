using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Sound controller, currently only for player jumps
 */
public class UpdateAudio : MonoBehaviour {

	private bool jumpSoundPlayed;
	
	private PlayerState state;
	private AudioSource jump;

	// Use this for initialization
	void Awake () {
		jump = GetComponent<AudioSource>();
		state = GetComponent<PlayerState>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!state.onGround && !jumpSoundPlayed){
			jump.Play();
			jumpSoundPlayed = true;
		}
		
		if(state.onGround){
			jumpSoundPlayed = false;
		}
	}
}
