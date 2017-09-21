using UnityEngine;

public class Crystal : InteractionObject, Interactive
{
    void Interactive.Interaction()
    {
        //InGameManager.Instance.PlayerDataContainer_readonly._PlayerStatus.IsCrystal = true;

        IngameButtonManager.Instance.canAction = false;

        Destroy(this.gameObject);
    }
}