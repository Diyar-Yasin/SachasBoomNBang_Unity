using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUppercutState : IEnemyState
{
    private const int FRAME_TIME = 120;
    private int currFrame = FRAME_TIME;

    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)
    {
        Animate(enemy);

        if (currFrame > 0)
        {
            return enemy.uppercutState;
        } else
        {
            currFrame = FRAME_TIME;
            return enemy.idleState;
        }
        
    }

    private void Animate(EnemySearch_ClassBased enemy)
    {
        enemy.GetComponent<SpriteRenderer>().sprite = GameAssets.i.enemyUppercut5;
        currFrame--;
    }
}
