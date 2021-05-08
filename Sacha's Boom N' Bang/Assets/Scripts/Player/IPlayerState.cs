using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IPlayerState
//              This is an interface which allows me to define states for the player's
//          finite state machine (FSM).
//
//          Note: The DoState function will be the staple function of every other state script.
//
//          Credits: https://www.youtube.com/watch?v=nnrOhb5UdRc&ab_channel=OneWheelStudio
public interface IPlayerState 
{
    IPlayerState DoState(PlayerSearch_ClassBased player);
}