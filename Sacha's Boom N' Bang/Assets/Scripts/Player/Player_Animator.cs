using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animator : MonoBehaviour
{
    private bool notInMotion;                                                                                 // Checks if the player is not idling. This should be true if we are currently going through our 
                                                                                                              //   "got hit" animation.
    private SpriteRenderer currSpirte;
    private Sprite idle1;
    private Sprite idle2;
    private Sprite block1;
    private Sprite block2;
    private float idleMoveWaitTime;
    private bool notRunningIdleCour;
    private const float FRAME_TIME = 0.1f;
    private const float MAX_IDLE_WAIT_TIME = 2f;

    void Start()
    {
        currSpirte = GetComponent<SpriteRenderer>();
        idle1 = GameAssets.i.idle1;
        idle2 = GameAssets.i.idle2;
        block1 = GameAssets.i.block1;
        block2 = GameAssets.i.block2;

        currSpirte.sprite = idle1;
        idleMoveWaitTime = MAX_IDLE_WAIT_TIME;
        notRunningIdleCour = true;
        notInMotion = true;
    }

    void Update()
    {
        if (notInMotion) // we wait for a period of time before allowing another move to register, if a move ever does
        {
            if (Input.GetButtonDown("Block"))
            {
                // BLOCK
                notInMotion = false;
                StartCoroutine(Block());
            } else if (Input.GetButtonDown("Left"))
            {
                // DODGE LEFT
                notInMotion = false;
                StartCoroutine(DodgeLeft());
            } else if (Input.GetButtonDown("Right"))
            {
                // DODGE RIGHT
                notInMotion = false;
                StartCoroutine(DodgeRight());
            } else if (Input.GetButtonDown("Jab"))
            {
                // JAB
                notInMotion = false;
                StartCoroutine(Jab());
            } else if (Input.GetButtonDown("Punch")) 
            {
                // PUNCH
                notInMotion = false;
                StartCoroutine(Punch());
            } else if (notRunningIdleCour)
            {
                // IDLE
                notRunningIdleCour = false;
                StartCoroutine(Idle());
                
            }
        }
    }

    IEnumerator DodgeLeft()
    {
        yield return new WaitForSeconds(FRAME_TIME);
        notInMotion = true;
    }

    IEnumerator DodgeRight()
    {
        yield return new WaitForSeconds(FRAME_TIME);
        notInMotion = true;
    }

    IEnumerator Jab()
    {
        yield return new WaitForSeconds(FRAME_TIME);
        notInMotion = true;
    }

    IEnumerator Punch()
    {
        yield return new WaitForSeconds(FRAME_TIME);
        notInMotion = true;
    }

    IEnumerator Idle()
    {
        if (idleMoveWaitTime > 0)
        {
            idleMoveWaitTime -= Time.deltaTime;
        } else
        {
            currSpirte.sprite = idle2;
            yield return new WaitForSeconds(FRAME_TIME * 2);
            currSpirte.sprite = idle1;
            idleMoveWaitTime = MAX_IDLE_WAIT_TIME;
        }

        notRunningIdleCour = true;
    }

    IEnumerator Block()
    {
        currSpirte.sprite = block1;
        yield return new WaitForSeconds(FRAME_TIME);
        currSpirte.sprite = block2;
        yield return new WaitForSeconds(FRAME_TIME * 5);
        currSpirte.sprite = idle1;
        notInMotion = true;
    }
}