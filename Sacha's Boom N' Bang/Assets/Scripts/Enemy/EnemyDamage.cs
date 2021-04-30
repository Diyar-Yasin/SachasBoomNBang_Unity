using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Sprite normal;
    public Sprite damaged;
    public Sprite invicible;

    private GameObject player;
    SpriteRenderer currSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        currSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((string.Compare(player.GetComponent<PlayerSearch_ClassBased>().currentStateName, "AttackLeftState") == 0) ||
        (string.Compare(player.GetComponent<PlayerSearch_ClassBased>().currentStateName, "AttackRightState") == 0))
        {
            currSprite.sprite = damaged;
        } else 
        {
            currSprite.sprite = normal;
        }
    }
}
