using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : IPlayerState
{
    private const float FRAME_TIME = 0.1f;

    public IPlayerState DoState(PlayerSearch_ClassBased player)
    {
        // Call the block function, if we ever want to access player just use player.x
        AnimateBlock(player);

        // Use if statements to determine what state to return
        // E.g.
        // return player.idleState;

        // If we get a new state we would have to add that to our list of considerations in the form of another else if
        if (Input.GetButtonDown("Block"))
        {
            return player.blockState;
        } else
        {
            return player.idleState;
        }
    }

    private void AnimateBlock(PlayerSearch_ClassBased player)
    {
        float idleMoveWaitTime = FRAME_TIME;
        SpriteRenderer currSpirte = player.GetComponent<SpriteRenderer>();

        currSpirte.sprite = GameAssets.i.block1;
        
        while (idleMoveWaitTime > 0)
        {
            idleMoveWaitTime -= Time.deltaTime;
        }

        currSpirte.sprite = GameAssets.i.block2;
        
        idleMoveWaitTime = FRAME_TIME * 5;
        while (idleMoveWaitTime > 0)
        {
            idleMoveWaitTime -= Time.deltaTime;
        }
    }
}
