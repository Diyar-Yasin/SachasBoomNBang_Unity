using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UNDER CONSTRUCTION: The wind up time should not damage the player (it does right now).
public class EnemyAtckState : IEnemyState
{
    private const int FRAME_TIME = 320;
    private const int LAST_FRAME = 1;
    private const float CANCELLABLE_TIME = FRAME_TIME * 0.5f;
    private const float WIND_UP_TIME = FRAME_TIME * 0.25f;
    private SpriteRenderer currSprite;
    private int currFrame = FRAME_TIME;
    

    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)
    {
        currSprite = enemy.GetComponent<SpriteRenderer>();

        if (currFrame > CANCELLABLE_TIME)
        {
            currSprite.sprite = GameAssets.i.enemyPunch1;
        } else if (currFrame > WIND_UP_TIME)
        {
            currSprite.sprite = GameAssets.i.enemyPunch2;
        } else
        {
            currSprite.sprite = GameAssets.i.enemyPunch3;
        }

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
