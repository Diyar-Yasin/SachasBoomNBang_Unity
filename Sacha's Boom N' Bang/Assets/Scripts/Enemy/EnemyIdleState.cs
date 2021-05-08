using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyIdleState
//              The main state for the enemy. All other states branch from here.
public class EnemyIdleState : IEnemyState
{
    // PRIVATE
    private const int FRAME_TIME = 360;
    private const int LAST_FRAME = 1;
    private const float ADJUSTMENT_TIME_1 = FRAME_TIME * (2.0f / 5.0f);
    private const float ADJUSTMENT_TIME_2 = FRAME_TIME * (1.0f / 5.0f);

    private int currFrame = FRAME_TIME;
    private SpriteRenderer currSprite;

    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)
    {
        Animate(enemy);

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

    private void Animate(EnemySearch_ClassBased enemy)                                                                 // Determines what sprite to show for the enemy.
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
    }
}
