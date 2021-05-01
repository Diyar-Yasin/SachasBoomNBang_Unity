using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState 
{
    IEnemyState DoState(EnemySearch_ClassBased enemy, GameObject player);
}