using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearch_ClassBased : MonoBehaviour
{
    public string currentStateName;
    private IPlayerState currentState;

    public IdleState idleState = new IdleState();
    public BlockState blockState = new BlockState();
    public DodgeLeftState dodgeLState = new DodgeLeftState();
    public DodgeRightState dodgeRState = new DodgeRightState();
    public AttackLeftState atckLState = new AttackLeftState();
    public AttackRightState atckRState = new AttackRightState();

    private void OnEnable()
    {
        currentState = idleState;
    }

    void Update()
    {
        currentState = currentState.DoState(this);
        currentStateName = currentState.ToString();
    }
}
