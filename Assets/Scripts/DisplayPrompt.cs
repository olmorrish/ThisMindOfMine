using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Thought bubble popup controller
 * Checks collision with player character to enable message to show
 */
public class DisplayPrompt : MonoBehaviour {

	private Renderer rend;
	private Renderer[] renderers;
	private Collider2D parentTipStoneHB;
	private Collider2D playerHB;

	// Use this for initialization
	void Start () {
		rend = gameObject.GetComponent<Renderer>();
		renderers = GetComponentsInChildren<Renderer>();
		parentTipStoneHB = gameObject.transform.parent.gameObject.GetComponent<Collider2D>();
		playerHB = GameObject.Find("Player").GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(parentTipStoneHB.IsTouching(playerHB)){
			foreach(Renderer rend in renderers) {
				rend.enabled = true;

			}
		}
		else{
			foreach(Renderer rend in renderers) {
				rend.enabled = false;

			}
		}
		
	}
}
