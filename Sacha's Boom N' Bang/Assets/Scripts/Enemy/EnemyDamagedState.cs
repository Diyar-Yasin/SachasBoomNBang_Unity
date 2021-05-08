using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyDamagedState
//              The enemy's damaged state.
//
//          Under Construction: Enemy health bar and health is still being implemented.
public class EnemyDamagedState : IEnemyState
{
    // PUBLIC
    public Healthbar healthbar;

    // PRIVATE
    private const int FRAME_TIME = 240;
    private const int LAST_FRAME = 1;
    private const string playerAtckL = "AttackLeftState";
    private const string playerAtckR = "AttackRightState";
    
    private Vector3 moveUp = Vector3.up * 0.3f;
    private int currFrame = FRAME_TIME;
    private PlayerSearch_ClassBased playerState;
    private bool hitByLeft;
    private int timesToDamage = 6;                                                                                     // The number of times the player can reapply damage to enemy if quick enough in attacking before he
    private int currHealth = 50;                                                                                       //   forces back to idle
    
    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)
    {
        playerState = player.GetComponent<PlayerSearch_ClassBased>();
        healthbar.SetHealth(currHealth);
        
        if (currFrame == FRAME_TIME)
        {
            currHealth--;
            healthbar.SetHealth(currHealth);
            
            if (currHealth == 0)
            {
                return enemy.knockOutState;
            }

            if (string.Compare(playerState.currentStateName, playerAtckL) == 0)
            {
                hitByLeft = true;
            } else
            {
                hitByLeft = false;
            }

            enemy.transform.position += moveUp;

        } else if (currFrame == LAST_FRAME)
        {
            enemy.transform.position -= moveUp;
        }

        if (hitByLeft)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = GameAssets.i.enemyDamagedR;
        } else
        {
            enemy.GetComponent<SpriteRenderer>().sprite = GameAssets.i.enemyDamagedL;
        }
        
        currFrame--;
        

        if (currFrame > 0)
        {
            return enemy.dmgState;
        } else if (timesToDamage > 0 && ((string.Compare(playerState.currentStateName, playerAtckL) == 0) || 
                   (string.Compare(playerState.currentStateName, playerAtckR) == 0)))
        {
            timesToDamage--;
            currFrame = FRAME_TIME;
            return enemy.dmgState;
        } else
        {
            currFrame = FRAME_TIME;
            timesToDamage = 6;
            return enemy.idleState;
        }
    }
}
