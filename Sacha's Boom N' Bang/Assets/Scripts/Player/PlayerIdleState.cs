using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerState
{
    private const float FRAME_TIME = 0.1f;

    public IPlayerState DoState(PlayerSearch_ClassBased player)
    {
        // Call the idle function, if we ever want to access player just use player.x
        AnimateIdle(player);

        // Use if statements to determine what state to return
        // E.g.
        // return player.blockState;

        // If we get a new state we would have to add that to our list of considerations in the form of another else if
        if (Input.GetButtonDown("Block"))
        {
            return player.blockState;
        } else
        {
            return player.idleState;
        }
    }

    private void AnimateIdle(PlayerSearch_ClassBased player)
    {
        float idleMoveWaitTime = 4f;
        SpriteRenderer currSpirte = player.GetComponent<SpriteRenderer>();
        currSpirte.sprite = GameAssets.i.idle2;
        Debug.Log(GameAssets.i.idle2);

        while (idleMoveWaitTime > 0)
        {
            idleMoveWaitTime -= Time.deltaTime;
        }

        currSpirte.sprite = GameAssets.i.idle2;
        Debug.Log("We made it");

        idleMoveWaitTime = FRAME_TIME * 2;
        while (idleMoveWaitTime > 0)
        {
            idleMoveWaitTime -= Time.deltaTime;
        }

        currSpirte.sprite = GameAssets.i.idle1;
    }
}
