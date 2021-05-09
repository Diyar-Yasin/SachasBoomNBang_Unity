using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AttackLeftState
//              The player's left attack. This state can be 'cancelled' and send the player 
//          directly into the damage state. If the attack runs successfully then the player 
//          will return to idle.
public class AttackLeftState : IPlayerState
{
    // PRIVATE
    private const double FRAME_TIME = 180; 
    private const int LAST_FRAME = 1;
    private const double FIRST_THIRD = 13.0 / 18.0;
    private const double SECOND_THIRD = 4.0 / 9.0;

    private Vector3 moveUp = Vector3.up * 0.1f;
    private double currFrame = FRAME_TIME;
    private bool jumpBuffer = false;
    private SpriteRenderer currSpirte;

    public IPlayerState DoState(PlayerSearch_ClassBased player)
    {
        Animate(player);
        
        if (string.Compare((GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemySearch_ClassBased>().currentStateName), "EnemyAtckState") == 0)
        {
            currFrame = FRAME_TIME;
            return player.dmgState;
        }

        if (currFrame > 0)
        {
            return player.atckLState;
        } else if (jumpBuffer)
        {
            currFrame = FRAME_TIME;
            jumpBuffer = false;
            return player.atckRState;
        } else
        {
            currFrame = FRAME_TIME;
            return player.idleState;
        }
    }

    private void Animate(PlayerSearch_ClassBased player)                                                               // Determines what sprite to show on screen.
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
        } else                                                                                                         // Here is where we check for player input and store if input was a right attack 
        {                                                                                                              //   so that we can use jump-buffering.
            currSpirte.sprite = GameAssets.i.atckLeft3;

            if (Input.GetButtonDown("Punch"))
            {
                jumpBuffer = true;
            }
        }

        currFrame--;
    }
}
