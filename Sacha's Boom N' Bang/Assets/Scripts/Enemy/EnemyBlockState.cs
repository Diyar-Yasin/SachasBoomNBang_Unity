using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockState : IEnemyState
{
    private const int FRAME_TIME = 80; // This number was determined from the fact that the impact frame of player attack is the last 80 frames
    private const int LAST_FRAME = 1;
    private int currFrame = FRAME_TIME;

    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)
    {
        enemy.GetComponent<SpriteRenderer>().sprite = GameAssets.i.enemyBlock;
        currFrame--;

        if (currFrame > 0)
        {
            return enemy.blockState;
        } else
        {
            currFrame = FRAME_TIME;
            return enemy.idleState;
        }
    }
}
