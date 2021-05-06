using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IEnemyState
{
    private const int FRAME_TIME = 360;
    private const int LAST_FRAME = 1;
    private int currFrame = FRAME_TIME;
    private const float ADJUSTMENT_TIME_1 = FRAME_TIME * (2.0f / 5.0f);
    private const float ADJUSTMENT_TIME_2 = FRAME_TIME * (1.0f / 5.0f);

    private SpriteRenderer currSprite;

    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)
    {
        currSprite = enemy.GetComponent<SpriteRenderer>();

        if (currFrame > ADJUSTMENT_TIME_1)
        {
            currSprite.sprite = GameAssets.i.enemyIdle1;
        } else if (currFrame > ADJUSTMENT_TIME_2)
        {
            currSprite.sprite = GameAssets.i.enemyIdle2;
        } else {
            currSprite.sprite = GameAssets.i.enemyIdle1;
        }
        currFrame--;

        if ((string.Compare(player.GetComponent<PlayerSearch_ClassBased>().currentStateName, "AttackLeftState") == 0) ||
        ((string.Compare(player.GetComponent<PlayerSearch_ClassBased>().currentStateName, "AttackRightState") == 0)))
        {
            return enemy.blockState;
        } else if (currFrame > 0)
        {
            return enemy.idleState;
        } else
        {
            currFrame = FRAME_TIME;
            int randomChoice = Random.Range(0, 2); // Can we make a better way to choose our attack?
            
            if (randomChoice == 0)
            {
                return enemy.punchWindState;
            } else
            {
                return enemy.uppercutWindupState;
            }
            
        }
        
    }
}
