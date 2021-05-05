using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch_ClassBased : MonoBehaviour
{
    public string currentStateName;
    private IEnemyState currentState;
    private GameObject player;

    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyPunchState punchState = new EnemyPunchState();
    public EnemyDamagedState dmgState = new EnemyDamagedState();
    public EnemyBlockState blockState = new EnemyBlockState();
    public EnemyUppercutState uppercutState = new EnemyUppercutState();

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