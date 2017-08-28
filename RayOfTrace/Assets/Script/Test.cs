using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private ThunderBolt thunder;

    private PlayerDataContainer container;

    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = InGameManager.Instance.PlayerDataContainer_readonly._PlayerManager;
   }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        //    StartCoroutine(thunder.Lighting());

        //if (Input.GetKeyDown(KeyCode.W))
        //    playerManager.Jump();
    }
}