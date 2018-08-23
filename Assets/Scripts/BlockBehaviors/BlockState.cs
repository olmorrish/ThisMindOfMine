using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : MonoBehaviour { 

	public bool isSpawned = false;  //acts as the trigger for animations
	public bool exiled = false;		//an exiled block has finished despawning and has been deactivated
	public string shortName; 
	public bool snappedToPreview = false;
}
