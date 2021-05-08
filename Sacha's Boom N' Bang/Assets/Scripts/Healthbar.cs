using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Healthbar
//              General healthbar script for both player and enemy.
//
//          Credits: https://www.youtube.com/watch?v=BLfNP4Sc_iA&ab_channel=Brackeys
//
//          Under Construction: This script causes a null reference exception because we are not
//          using instances of the player/enemy when calling these functions in other scripts.
public class Healthbar : MonoBehaviour
{
    public Slider slider;
    
    public void CreateHealth(int maxHealth)
    {

        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}