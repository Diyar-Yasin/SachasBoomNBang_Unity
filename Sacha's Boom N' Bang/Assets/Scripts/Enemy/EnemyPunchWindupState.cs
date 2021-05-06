using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPunchWindupState : IEnemyState
{
    private const int FRAME_TIME = 240;
    private const float CANCELLABLE_FRAME = FRAME_TIME * 0.5f;
    private const string playerAtckL = "AttackLeftState";
    private const string playerAtckR = "AttackRightState";

    private SpriteRenderer currSprite;
    private PlayerSearch_ClassBased playerState;
    private bool cancel;
    private int currFrame = FRAME_TIME;

    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)
    {
        cancel = CheckForCancels(enemy, player);

        if (cancel)
        {
            currFrame = FRAME_TIME;
            cancel = false;
            return enemy.dmgState;
        }

        Animate(enemy);

        if (currFrame > 0)
        {
            return enemy.punchWindState;
        } else 
        {
            currFrame = FRAME_TIME;
            cancel = false;
            return enemy.punchState;
        }
    }

    private bool CheckForCancels(EnemySearch_ClassBased enemy, GameObject player) // Checks if the player is attacking us during 
    {
        if (currFrame > CANCELLABLE_FRAME) // The enemy can only be cancelled during his golden frame
        {
            return false;
        }

        playerState = player.GetComponent<PlayerSearch_ClassBased>();

        if ((string.Compare(playerState.currentStateName, playerAtckL) == 0) || 
            (string.Compare(playerState.currentStateName, playerAtckR) == 0))
        {
            return true;
        }
        return false;
    }

    private void Animate(EnemySearch_ClassBased enemy)
    {
        currSprite = enemy.GetComponent<SpriteRenderer>();

        if (currFrame > CANCELLABLE_FRAME)
        {
            // Also check for cancelling here later!
            currSprite.sprite = GameAssets.i.enemyPunch1;
        } else
        {
            currSprite.sprite = GameAssets.i.enemyPunch2;
        } 
        currFrame--;
    }
}
