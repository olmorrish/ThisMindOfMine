using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Changes the player's State when the foot hitbox collides with the ground
 * The reference to the player object MUST be defined in Unity for this script to be able
 *  to locate the player's state. 
 * This script should be attached to the object w/hitbox to reset jump
 */
public class FootCollisionResetJump : MonoBehaviour
{

    public GameObject playerObjReference;   //
    private PlayerState state;

    public int jumpCooldown = 20;    //frames after a jump until the collision trigger can occur again; prevents resent while starting a jump. 
    private int cooldown;

    void Awake()
    {
        state = playerObjReference.GetComponent<PlayerState>();
        cooldown = 0;
    }

    private void Update()
    {
        //update cooldown ea frame
        if (cooldown < jumpCooldown)
        {
            cooldown++;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (cooldown == jumpCooldown)
        {
            state.onGround = true;
            state.jumpHeldDown = false;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {

        if (cooldown == jumpCooldown)
        {
            state.onGround = true;
            state.jumpHeldDown = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //start the cooldown count up
        cooldown = 0;
    }
}
