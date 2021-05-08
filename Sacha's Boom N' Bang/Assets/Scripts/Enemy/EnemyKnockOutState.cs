using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyKnockOutState
//              The final enemy state where he is defeated.
//
//          Under Construction: This entire state is currently not implemented and still requires
//          art assets.
public class EnemyKnockOutState : IEnemyState
{
    public IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player)                                        // here the game would transition to the win cutscene
    {
        return enemy.knockOutState;
    }
}
