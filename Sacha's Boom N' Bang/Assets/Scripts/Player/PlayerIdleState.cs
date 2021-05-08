using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IdleState
//              The player's idle state. This state does all the checking for input and acts as the source from which all other
//          player states branch off from.
public class IdleState : IPlayerState
{
    // PRIVATE
    private const string enemyPunchState = "EnemyPunchState";
    private const string enemyUppercutState = "EnemyUppercutState";
    private EnemySearch_ClassBased enemy;

    public IPlayerState DoState(PlayerSearch_ClassBased player)
    {
        player.GetComponent<SpriteRenderer>().sprite = GameAssets.i.idle1;                                             // Use if statements to determine what state to return
                                                                                                                       // E.g. return player.blockState;
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemySearch_ClassBased>();

        if ((string.Compare((enemy.currentStateName), enemyPunchState) == 0) ||
            (string.Compare(enemy.currentStateName, enemyUppercutState) == 0))
        {
            return player.dmgState;
        }
        
        if (Input.GetButtonDown("Block"))
        {
            return player.blockState;
        } else if (Input.GetButtonDown("Left"))
        {
            return player.dodgeLState;
        } else if (Input.GetButtonDown("Right"))
        {
            return player.dodgeRState;
        } else if (Input.GetButtonDown("Jab"))
        {
            return player.atckLState;
        } else if (Input.GetButtonDown("Punch"))
        {
            return player.atckRState;
        } else
        {
            return player.idleState;
        }
    }
}
