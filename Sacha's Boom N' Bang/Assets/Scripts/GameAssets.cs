using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameAssets
//              This script allows you to access instances of assets from any other script.
//
//          CREDITS: https://www.youtube.com/watch?v=iD1_JczQcFY&ab_channel=CodeMonkey
public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null)
            {
                _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            }

            return _i;
        }
    }

    // Player Sprite Assets
    public Sprite idle1;
    public Sprite idle2;

    public Sprite block1;
    public Sprite block2;

    public Sprite dodgeLeft;
    public Sprite dodgeRight;

    public Sprite atckLeft1;
    public Sprite atckLeft2;
    public Sprite atckLeft3;
    
    public Sprite atckRight1;
    public Sprite atckRight2;
    public Sprite atckRight3;

    public Sprite damaged1;
    public Sprite damaged2;

    // Enemy Sprite Assets
    public Sprite enemyIdle1;
    public Sprite enemyIdle2;

    public Sprite enemyPunch1;
    public Sprite enemyPunch2;
    public Sprite enemyPunch3;

    public Sprite enemyBlock;

    public Sprite enemyUppercut1;
    public Sprite enemyUppercut2;
    public Sprite enemyUppercut3;
    public Sprite enemyUppercut4;
    public Sprite enemyUppercut5;

    public Sprite enemyDamagedR;
    public Sprite enemyDamagedL;
}
