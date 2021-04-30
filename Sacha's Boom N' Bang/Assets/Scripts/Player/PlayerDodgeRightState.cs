using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeRightState : IPlayerState
{
    private const int FRAME_TIME = 240;
    private const int LAST_FRAME = 1;
    private Vector3 moveRight = Vector3.right * 0.4f;
    private int currFrame = FRAME_TIME;
    SpriteRenderer currSpirte;

    public IPlayerState DoState(PlayerSearch_ClassBased player)
    {
        Animate(player);
        
        if (Input.GetButtonDown("Right") || currFrame > 0)
        {
            return player.dodgeRState;
        } else
        {
            currFrame = FRAME_TIME;
            return player.idleState;
        }
    }

    private void Animate(PlayerSearch_ClassBased player)
    {
        currSpirte = player.GetComponent<SpriteRenderer>();

        if (currFrame == FRAME_TIME)
        {
            player.transform.position += moveRight;
        } else if (currFrame == LAST_FRAME)
        {
            player.transform.position -= moveRight;
        }

        currSpirte.sprite = GameAssets.i.dodgeRight;
        currFrame--;
    }
}
