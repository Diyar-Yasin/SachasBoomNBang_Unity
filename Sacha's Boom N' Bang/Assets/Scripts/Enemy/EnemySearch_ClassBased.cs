using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemySearch_ClassBased
//              This function constantly calls the DoState of the current state the enemy is in
//          and then gets the next state. Begins with the idle state.
public class EnemySearch_ClassBased : MonoBehaviour
{
    // PRIVATE
    private IEnemyState currentState;
    private GameObject player;

    // PUBLIC
    public string currentStateName;
    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyPunchState punchState = new EnemyPunchState();
    public EnemyPunchWindupState punchWindState = new EnemyPunchWindupState();
    public EnemyKnockOutState knockOutState = new EnemyKnockOutState();
    public EnemyDamagedState dmgState = new EnemyDamagedState();
    public EnemyBlockState blockState = new EnemyBlockState();
    public EnemyUppercutState uppercutState = new EnemyUppercutState();
    public EnemyUppercutWindupState uppercutWindupState = new EnemyUppercutWindupState();

    private void OnEnable()
    {
        currentState = idleState;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        currentState = currentState.DoState(this, player);
        currentStateName = currentState.ToString();
    }
}