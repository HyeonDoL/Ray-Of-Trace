using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour
{
    private Transform playerTrans;
    [SerializeField]
    private InGameManager ingameManager;
  
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ingameManager.NowCrash = this.gameObject;
            ingameManager.candeletecrash = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            ingameManager.NowCrash = this.gameObject;
            ingameManager.candeletecrash = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ingameManager.NowCrash = null;
            ingameManager.candeletecrash = false;
        }
    }
    private void Start()
    {
        playerTrans = InGameManager.Instance.PlayerDataContainer_readonly.PlayerTrans;
    }

    
}