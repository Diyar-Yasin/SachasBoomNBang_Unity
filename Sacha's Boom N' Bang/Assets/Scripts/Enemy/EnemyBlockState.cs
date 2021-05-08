using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyBlockState
//              State where enemy blocks the player's attacks. This state plays whenever the player
//          tries to attack the enemy and he is not winding up an attack.
public class EnemyBlockState : IEnemyState
{
    // PRIVATE
    private const int FRAME_TIME = 80;                                                                                 // This number was determined from the fact that 
    private const int LAST_FRAME = 1;                                                                                  //   the impact frame of player attack is the last 80 frames.

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
