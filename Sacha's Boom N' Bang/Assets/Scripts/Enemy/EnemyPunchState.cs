using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyPunchState
//              This is the impact part of the punch. See EnemyPunchWindupState.cs for
//          details.
public class EnemyPunchState : IEnemyState
{
    // PRIVATE
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

    private void Animate(EnemySearch_ClassBased enemy)                                                                 // Determines what sprite to show for the enemy.
    {
        currSprite = enemy.GetComponent<SpriteRenderer>();
        currSprite.sprite = GameAssets.i.enemyPunch3;
        currFrame--;
    }
}
