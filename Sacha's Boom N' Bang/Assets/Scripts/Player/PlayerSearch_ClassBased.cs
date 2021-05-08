using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerSearch_ClassBased
//              This function constantly calls the DoState of the current state the player is in
//          and then gets the next state. Begins with the idle state.
public class PlayerSearch_ClassBased : MonoBehaviour
{
    // PRIVATE
    private IPlayerState currentState;

    // PUBLIC
    public string currentStateName;
    public IdleState idleState = new IdleState();
    public BlockState blockState = new BlockState();
    public DodgeLeftState dodgeLState = new DodgeLeftState();
    public DodgeRightState dodgeRState = new DodgeRightState();
    public AttackLeftState atckLState = new AttackLeftState();
    public AttackRightState atckRState = new AttackRightState();
    public DamageState dmgState = new DamageState();

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
