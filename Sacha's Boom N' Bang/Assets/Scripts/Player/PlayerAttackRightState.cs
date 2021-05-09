using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AttackRightState
//              The player's right attack. This state can be 'cancelled' and send the player 
//          directly into the damage state. If the attack runs successfully then the player 
//          will return to idle.
public class AttackRightState : IPlayerState
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
            return player.atckRState;
        } else if (jumpBuffer)
        {
            currFrame = FRAME_TIME;
            jumpBuffer = false;
            return player.atckLState;
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
            currSpirte.sprite = GameAssets.i.atckRight1;
        } else if (currFrame > FRAME_TIME * SECOND_THIRD)
        {
            currSpirte.sprite = GameAssets.i.atckRight2;
        } else                                                                                                                                      
        {
            currSpirte.sprite = GameAssets.i.atckRight3;

            if (Input.GetButtonDown("Jab"))                                                                            // Here is where we check for player input and store if input was a right attack 
            {                                                                                                          //   so that we can use jump-buffering.
                jumpBuffer = true;
            }
        }

        currFrame--;
    }
}
