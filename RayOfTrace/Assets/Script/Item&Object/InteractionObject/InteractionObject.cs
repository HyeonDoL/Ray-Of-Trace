using System;
using UnityEngine;

public class InteractionObject : MonoBehaviour, Interactive
{
    private PlayerInteraction playerInteraction;

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IngameButtonManager.Instance.canAction = true;

            playerInteraction = col.gameObject.GetComponent<PlayerInteraction>();

            playerInteraction._InteractionObject = this;
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerInteraction._InteractionObject == null)
            {
                playerInteraction = other.gameObject.GetComponent<PlayerInteraction>();

                playerInteraction._InteractionObject = this;
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IngameButtonManager.Instance.canAction = false;

            playerInteraction._InteractionObject = null;
        }
    }

    void Interactive.Interaction()
    {
        // 구현은 자식부분에서, interface 특성상 명시적으로 구현만 해둠
    }
}