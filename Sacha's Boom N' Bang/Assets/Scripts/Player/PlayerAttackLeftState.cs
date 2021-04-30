using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLeftState : IPlayerState
{
    private const double FRAME_TIME = 180; 
    private const int LAST_FRAME = 1;
    private Vector3 moveUp = Vector3.up * 0.1f;
    private const double FIRST_THIRD = 13.0 / 18.0;
    private const double SECOND_THIRD = 4.0 / 9.0;
    private double currFrame = FRAME_TIME;
    SpriteRenderer currSpirte;

    public IPlayerState DoState(PlayerSearch_ClassBased player)
    {
        Animate(player);
        
        if (Input.GetButtonDown("Jab") || currFrame > 0)
        {
            return player.atckLState;
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
            player.transform.position += moveUp;
        } else if (currFrame == LAST_FRAME)
        {
            player.transform.position -= moveUp;
        }

        if (currFrame > FRAME_TIME * FIRST_THIRD)
        {
            currSpirte.sprite = GameAssets.i.atckLeft1;
        } else if (currFrame > FRAME_TIME * SECOND_THIRD)
        {
            currSpirte.sprite = GameAssets.i.atckLeft2;
        } else
        {
            currSpirte.sprite = GameAssets.i.atckLeft3;
        }

        currFrame--;
    }
}
