using UnityEngine;

public class TeleportExit : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InGameManager.Instance.NowWhite = this.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InGameManager.Instance.NowWhite = this.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InGameManager.Instance.NowWhite = null;
        }
    }

    private void OnEnable()
    {
        InGameManager.Instance.SetTeleportExitTrans(this.transform);
    }

    private void OnDisable()
    {
        InGameManager.Instance.RemoveTeleportExitTrans(this.transform);
    }
}