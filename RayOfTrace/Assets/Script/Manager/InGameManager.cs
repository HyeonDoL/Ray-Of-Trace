using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance = null;
    public static InGameManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("InGameManager").AddComponent<InGameManager>();
        }
    }

    [SerializeField]
    private PlayerDataContainer playerDataContainer;

    private void Awake()
    {
        instance = this;
    }

    public PlayerDataContainer PlayerDataContainer_readonly { get { return playerDataContainer; } }
}