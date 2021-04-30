using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeLeftState : IPlayerState
{
    private const int FRAME_TIME = 240;
    private const int LAST_FRAME = 1;
    private Vector3 moveLeft = Vector3.left * 0.4f;
    private int currFrame = FRAME_TIME;
    SpriteRenderer currSpirte;

    public IPlayerState DoState(PlayerSearch_ClassBased player)
    {
        Animate(player);

        if (Input.GetButtonDown("Left") || currFrame > 0)
        {
            return player.dodgeLState;
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
            player.transform.position += moveLeft;
        } else if (currFrame == LAST_FRAME)
        {
            player.transform.position -= moveLeft;
        }

        currSpirte.sprite = GameAssets.i.dodgeLeft;
        currFrame--;
    }
}
