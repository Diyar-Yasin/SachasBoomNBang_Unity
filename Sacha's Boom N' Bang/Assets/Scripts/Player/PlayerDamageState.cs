using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DamageState
//              The player's damaged state. This state simply plays the animation and does no checking for
//          the enemies state because the player will never take damage in this state.
public class DamageState : IPlayerState
{
    // PRIVATE
    private const int FRAME_TIME = 120;
    private const int LAST_FRAME = 1;
    private const float ONE_THIRD = 1.0f / 3.0f;
    
    private int currFrame = FRAME_TIME;

    public IPlayerState DoState(PlayerSearch_ClassBased player)
    {
        Animate(player);

        if (currFrame > 0)
        {
            return player.dmgState;
        } else 
        {
            currFrame = FRAME_TIME;
            return player.idleState;
        }
    }

    private void Animate(PlayerSearch_ClassBased player)                                                               // Determines what sprite to show on screen.
    {
        SpriteRenderer currSpirte = player.GetComponent<SpriteRenderer>();

        if (currFrame > FRAME_TIME * ONE_THIRD)
        {
            currSpirte.sprite = GameAssets.i.damaged1;
        }
        else
        {
            currSpirte.sprite = GameAssets.i.damaged2;
        }

        currFrame--;
    }
}
