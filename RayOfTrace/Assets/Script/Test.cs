using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private ThunderBolt thunder;

    [SerializeField]
    private PlayerDataContainer container;

    private Transform playerTrans;

    private void Awake()
    {
        playerTrans = container.PlayerTrans;
   }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            StartCoroutine(thunder.Lighting());
    }
}