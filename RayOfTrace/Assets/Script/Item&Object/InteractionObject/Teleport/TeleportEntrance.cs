using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEntrance : InteractionObject, Interactive
{
    private Transform playerTrans;

    private Transform GetNearTeleportExit()
    {
        List<Transform> teleportExitTransList = InGameManager.Instance.GetTeleportExitTransList();

        Transform nearTeleportTrans = teleportExitTransList[0];

        float minDistance = Vector2.Distance(transform.position, nearTeleportTrans.position);

        for (int i = 1; i < teleportExitTransList.Count; i++)
        {
            float distance = Vector2.Distance(transform.position, teleportExitTransList[i].position);

            if (minDistance > distance)
            {
                minDistance = distance;
                nearTeleportTrans = teleportExitTransList[i];
            }
        }

        return nearTeleportTrans;
    }

    private void Start()
    {
        playerTrans = InGameManager.Instance.PlayerDataContainer_readonly.PlayerTrans;
    }

    void Interactive.Interaction()
    {
        playerTrans.position = GetNearTeleportExit().position;
    }
}