using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UNDER CONSTRUCTION: The wind up time should not damage the player (it does right now).
public class EnemyPunchState : IEnemyState
{
    private const int FRAME_TIME = 80;
    private const float WIND_UP_TIME = FRAME_TIME * 0.25f;

    private SpriteRenderer currSprite;
    private int currFrame = FRAME_TIME;
    

    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)
    {
        Animate(enemy);

        if (currFrame > 0)
        {
            return enemy.punchState;
        } else
        {
            currFrame = FRAME_TIME;
            return enemy.idleState;
        }
    }

    private void Animate(EnemySearch_ClassBased enemy)
    {
        currSprite = enemy.GetComponent<SpriteRenderer>();
        currSprite.sprite = GameAssets.i.enemyPunch3;
        currFrame--;
    }
}
