using System;
using UnityEngine;

public class ClearPoint : InteractionObject, Interactive
{
    [SerializeField]
    private GameObject crystal;

    void Interactive.Interaction()
    {
        if(InGameManager.Instance.PlayerDataContainer_readonly._PlayerStatus.IsCrystal)
        {
            crystal.SetActive(true);
        }
    }
}