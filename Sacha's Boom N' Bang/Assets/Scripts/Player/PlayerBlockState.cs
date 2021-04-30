using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : IPlayerState
{
    private const int FRAME_TIME = 240; 
    private int currFrame = FRAME_TIME;
    SpriteRenderer currSpirte;

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

    private void Animate(PlayerSearch_ClassBased player)
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
