using UnityEngine;

public class TeleportExit : MonoBehaviour
{

    private void OnEnable()
    {
        InGameManager.Instance.SetTeleportExitTrans(this.transform);
    }

    private void OnDisable()
    {
        InGameManager.Instance.RemoveTeleportExitTrans(this.transform);
    }
}