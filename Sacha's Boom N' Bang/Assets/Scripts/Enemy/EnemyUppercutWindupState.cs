using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUppercutWindupState : IEnemyState
{
    private const int FRAME_TIME = 400;
    private const float FIRST_FOURTH = FRAME_TIME * (4.0f / 5.0f);
    private const float SECOND_FOURTH = FRAME_TIME * (3.0f / 5.0f);
    private const float THIRD_FOURTH = FRAME_TIME * (1.0f / 2.0f);
    private const float CANCELLABLE_FRAME = FRAME_TIME * (3.0f / 10.0f);
    private const string playerAtckL = "AttackLeftState";
    private const string playerAtckR = "AttackRightState";

    private SpriteRenderer currSprite;
    private int currFrame = FRAME_TIME;
    private PlayerSearch_ClassBased playerState;
    private bool cancel;

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
            return enemy.uppercutWindupState;
        } else
        {
            currFrame = FRAME_TIME;
            cancel = false;
            return enemy.uppercutState;
        }
    }

    private bool CheckForCancels(EnemySearch_ClassBased enemy, GameObject player) // Checks if the player is attacking us during 
    {
        if (currFrame >  CANCELLABLE_FRAME)
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
        
        if (currFrame > FIRST_FOURTH)
        {
            currSprite.sprite = GameAssets.i.enemyUppercut1;
        } else if (currFrame > SECOND_FOURTH)
        {
            currSprite.sprite = GameAssets.i.enemyUppercut2;
        } else if (currFrame > THIRD_FOURTH)
        {
            currSprite.sprite = GameAssets.i.enemyUppercut3;
        } else 
        {
            currSprite.sprite = GameAssets.i.enemyUppercut4;
        }

        currFrame--;
    }
}
