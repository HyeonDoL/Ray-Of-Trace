using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private static InGameManager instance = null;
    public static InGameManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("*Manager").AddComponent<InGameManager>();
        }
    }

    [SerializeField]
    private PlayerDataContainer playerDataContainer;

    private List<Transform> teleportExitTransList = new List<Transform>();

    private void Awake()
    {
        instance = this;
    }

    public PlayerDataContainer PlayerDataContainer_readonly { get { return playerDataContainer; } }

    public void SetTeleportExitTrans(Transform teleportExitTrans)
    {
        teleportExitTransList.Add(teleportExitTrans);
    }
    public void RemoveTeleportExitTrans(Transform teleportExitTrans)
    {
        teleportExitTransList.Remove(teleportExitTrans);
    }
    
    public List<Transform> GetTeleportExitTransList()
    {
        return teleportExitTransList;
    }
}