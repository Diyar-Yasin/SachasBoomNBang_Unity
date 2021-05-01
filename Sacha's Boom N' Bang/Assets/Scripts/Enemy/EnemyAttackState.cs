using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtckState : IEnemyState
{
    private const int FRAME_TIME = 120;
    private const int LAST_FRAME = 1;
    private int currFrame = FRAME_TIME;

    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)
    {
        enemy.GetComponent<SpriteRenderer>().sprite = GameAssets.i.enemyAtck;
        currFrame--;

        if ((string.Compare(player.GetComponent<PlayerSearch_ClassBased>().currentStateName, "AttackLeftState") == 0) ||
        ((string.Compare(player.GetComponent<PlayerSearch_ClassBased>().currentStateName, "AttackRightState") == 0)))
        {
            return enemy.dmgState;
        } else if (currFrame > 0)
        {
            return enemy.atckState;
        } else
        {
            currFrame = FRAME_TIME;
            return enemy.idleState;
        }
    }
}
