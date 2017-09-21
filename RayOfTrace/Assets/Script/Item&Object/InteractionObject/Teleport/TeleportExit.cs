using UnityEngine;

public class TeleportExit : MonoBehaviour
{
    [SerializeField]
    private InGameManager ingameManager;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ingameManager.NowWhite = this.gameObject;
            ingameManager.cangetwhite = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            ingameManager.NowWhite = this.gameObject;
            ingameManager.cangetwhite = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ingameManager.NowWhite = null;
            ingameManager.cangetwhite = false;
        }
    }
    private void Awake()
    {
        InGameManager.Instance.SetTeleportExitTrans(this.transform);
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