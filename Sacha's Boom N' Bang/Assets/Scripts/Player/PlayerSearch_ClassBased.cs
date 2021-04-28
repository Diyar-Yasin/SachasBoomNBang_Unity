using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearch_ClassBased : MonoBehaviour
{
    private string currentStateName;
    private IPlayerState currentState;

    public IdleState idleState = new IdleState();
    public BlockState blockState = new BlockState();

    private void OnEnable()
    {
        currentState = idleState;
    }

    void Update()
    {
        currentState = currentState.DoState(this);
        currentStateName = currentState.ToString();
        Debug.Log(currentStateName);
    }
}
