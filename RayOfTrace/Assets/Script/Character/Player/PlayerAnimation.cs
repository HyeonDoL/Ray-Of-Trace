using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator playerAni;

    private PlayerState prevState = PlayerState.Idle;

    public void ChangeAni(PlayerState state)
    {
        if (prevState == state)
            return;

        switch(state)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Move:
                break;

            case PlayerState.Jump:
                break;

            case PlayerState.LightItem:
                break;

            case PlayerState.ShadowItem:
                break;

            case PlayerState.Die:
                break;

            default:
                Debug.LogError("Switch / Out of Range");
                break;
        }

        prevState = state;
    }

    public void StopAni()
    {
        switch (prevState)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Move:
                break;

            case PlayerState.Jump:
                break;

            case PlayerState.LightItem:
                break;

            case PlayerState.ShadowItem:
                break;

            case PlayerState.Die:
                break;

            default:
                Debug.LogError("Switch / Out of Range");
                break;
        }
    }
}