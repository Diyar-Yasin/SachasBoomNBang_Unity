using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch_ClassBased : MonoBehaviour
{
    public string currentStateName;
    private IEnemyState currentState;
    private GameObject player;

    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyAtckState atckState = new EnemyAtckState();
    public EnemyDamagedState dmgState = new EnemyDamagedState();

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