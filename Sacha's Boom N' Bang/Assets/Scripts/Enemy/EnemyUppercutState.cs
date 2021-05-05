using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUppercutState : IEnemyState
{
    private const int FRAME_TIME = 480;
    private const int LAST_FRAME = 1;
    private const float FIRST_FIFTH = FRAME_TIME * (4.0f / 5.0f);
    private const float SECOND_FIFTH = FRAME_TIME * (3.0f / 5.0f);
    private const float THIRD_FIFTH = FRAME_TIME * (1.0f / 2.0f);
    private const float FOURTH_FIFTH = FRAME_TIME * (1.0f / 5.0f);
    private SpriteRenderer currSprite;
    private int currFrame = FRAME_TIME;

    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)
    {
        Animate(enemy);

        if (currFrame > 0)
        {
            return enemy.uppercutState; // For now this is uncancellable
        } else
        {
            currFrame = FRAME_TIME;
            return enemy.idleState;
        }
        
    }

    private void Animate(EnemySearch_ClassBased enemy)
    {
        // Frames 1 -> 5 play out as:
        // 80, 80, 40, 120, 80 (in # of frames)
        currSprite = enemy.GetComponent<SpriteRenderer>();

        if (currFrame > FIRST_FIFTH)
        {
            currSprite.sprite = GameAssets.i.enemyUppercut1;
        } else if (currFrame > SECOND_FIFTH)
        {
            currSprite.sprite = GameAssets.i.enemyUppercut2;
        } else if (currFrame > THIRD_FIFTH)
        {
            currSprite.sprite = GameAssets.i.enemyUppercut3;
        } else if (currFrame > FOURTH_FIFTH)
        {
            currSprite.sprite = GameAssets.i.enemyUppercut4;
        } else
        {
            currSprite.sprite = GameAssets.i.enemyUppercut5;
        }

        currFrame--;
    }
}
