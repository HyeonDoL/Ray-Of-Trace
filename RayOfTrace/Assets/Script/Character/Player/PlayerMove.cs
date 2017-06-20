using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D playerRigid;

    private void Awake()
    {
        playerRigid = InGameManager.Instance.PlayerDataContainer_readonly.PlayerRigid;
    }

    public void Move(Vector2 direction)
    {
        direction.Normalize();

        playerRigid.MovePosition((Vector2)this.transform.position + direction * speed * Time.deltaTime);
    }
}