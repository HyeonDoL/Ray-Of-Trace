using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed;

    private Rigidbody2D playerRigid;

    private PlayerManager playerManager;
    
    [SerializeField] private bool isGround;

    private void Awake()
    {
        playerRigid = InGameManager.Instance.PlayerDataContainer_readonly.PlayerRigid;

        playerManager = InGameManager.Instance.PlayerDataContainer_readonly._PlayerManager;
    }

    public void Jump()
    {
        isGround = false;

        playerRigid.AddForce(this.transform.up * jumpSpeed, ForceMode2D.Impulse);
    }
    public bool Getjump()
    {
        return isGround;
    }
    private void FixedUpdate()
    {
        if (!isGround)
        {
            RaycastHit2D hitInfo;

            hitInfo = Physics2D.Raycast((Vector2)this.transform.position + new Vector2(0, -0.1f), this.transform.up * -1, 5f);

            if(hitInfo.collider == null)
            {
                isGround = true;
                Debug.Log(1);
                playerManager.Idle();
            }
        }
    }

   
}