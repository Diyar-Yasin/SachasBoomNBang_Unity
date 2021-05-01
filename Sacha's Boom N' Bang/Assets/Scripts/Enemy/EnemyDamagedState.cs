using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedState : IEnemyState
{
    private const int FRAME_TIME = 120;
    private const int LAST_FRAME = 1;
    private int currFrame = FRAME_TIME;

    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)
    {
        enemy.GetComponent<SpriteRenderer>().sprite = GameAssets.i.enemyDamaged;
        currFrame--;

        if (currFrame > 0)
        {
            return enemy.dmgState;
        } else
        {
            currFrame = FRAME_TIME;
            return enemy.idleState;
        }
    }
}
