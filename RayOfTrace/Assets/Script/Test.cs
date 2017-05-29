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
        {
            StartCoroutine(thunder.Lighting());
            PlayerChangePosition();
        }
    }

    private void PlayerChangePosition()
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        playerTrans.position = new Vector3(temp.x, playerTrans.position.y, 0);
    }
}