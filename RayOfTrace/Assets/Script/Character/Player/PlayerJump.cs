using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed;

    private Rigidbody2D playerRigid;

    private void Awake()
    {
        playerRigid = InGameManager.Instance.PlayerDataContainer_readonly.PlayerRigid;
    }

    public void Jump()
    {
        playerRigid.AddForce(this.transform.up * jumpSpeed, ForceMode2D.Impulse);
    }
}