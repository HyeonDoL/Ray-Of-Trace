using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    private Transform restartTrans;

    private Transform playerTrans;

    private void Awake()
    {
        playerTrans = InGameManager.Instance.PlayerDataContainer_readonly.PlayerTrans;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerTrans.position = restartTrans.position;
        }
    }
}