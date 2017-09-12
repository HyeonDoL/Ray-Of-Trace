using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Interactive interactionObject = null;

    public Interactive _InteractionObject
    {
        set
        {
            this.interactionObject = value;
        }
        get
        {
            return this.interactionObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Interaction();
    }

    public void Interaction()
    {
        if (interactionObject == null)
            return;

        interactionObject.Interaction();
    }
}

public interface Interactive
{
    void Interaction();
}