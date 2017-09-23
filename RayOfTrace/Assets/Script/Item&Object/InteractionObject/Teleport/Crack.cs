using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour
{
    private Transform playerTrans;

  
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InGameManager.Instance.NowCrash = this.gameObject;
            InGameManager.Instance.candeletecrash = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            InGameManager.Instance.NowCrash = this.gameObject;
            InGameManager.Instance.candeletecrash = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InGameManager.Instance.NowCrash = null;
            InGameManager.Instance.candeletecrash = false;
        }
    }
    private void Start()
    {
        playerTrans = InGameManager.Instance.PlayerDataContainer_readonly.PlayerTrans;
    }

    
}