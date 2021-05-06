using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerState
{
    private const string enemyPunchState = "EnemyPunchState";
    private const string enemyUppercutState = "EnemyUppercutState";
    private EnemySearch_ClassBased enemy;

    public IPlayerState DoState(PlayerSearch_ClassBased player)
    {
        // Call the idle function, if we ever want to access player just use player.x
        //AnimateIdle(player);
        player.GetComponent<SpriteRenderer>().sprite = GameAssets.i.idle1;

        // Use if statements to determine what state to return
        // E.g.
        // return player.blockState;

        // If we get a new state we would have to add that to our list of considerations in the form of another else if
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
