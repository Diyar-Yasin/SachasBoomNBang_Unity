using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BlockState
//              The player's block. This state simply plays the animation and does no checking for
//          the enemies state because the player will never take damage in this state.
//
//          UNDER CONSTRUCTION: I plan to add an exhaustion feature, just like Punch Out, where the
//          player eventually be unable to consecutively overblock.
public class BlockState : IPlayerState
{
    // PRIVATE
    private const int FRAME_TIME = 240; 
    
    private int currFrame = FRAME_TIME;
    private SpriteRenderer currSpirte;

    public IPlayerState DoState(PlayerSearch_ClassBased player)
    {
        Animate(player);
        
        if (Input.GetButtonDown("Block") || currFrame > 0)
        {
            return player.blockState;
        } else
        {
            currFrame = FRAME_TIME;
            return player.idleState;
        }
    }

    private void Animate(PlayerSearch_ClassBased player)                                                               // Determines what sprite to show on screen.
    {
        currSpirte = player.GetComponent<SpriteRenderer>();

        if (currFrame > FRAME_TIME * 0.75f)
        {
            currSpirte.sprite = GameAssets.i.block1;
        } else
        {
            currSpirte.sprite = GameAssets.i.block2;
        }

        currFrame--;
    }
}
