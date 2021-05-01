using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : IPlayerState
{
    private const int FRAME_TIME = 120;
    private const int LAST_FRAME = 1;
    private const float ONE_THIRD = 1.0f / 3.0f;
    private int currFrame = FRAME_TIME;

    public IPlayerState DoState(PlayerSearch_ClassBased player)
    {
        // change the sprite here
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

        if (currFrame > 0)
        {
            return player.dmgState;
        } else 
        {
            currFrame = FRAME_TIME;
            return player.idleState;
        }
    }
}
