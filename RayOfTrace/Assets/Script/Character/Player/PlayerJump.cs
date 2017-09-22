using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private float checkWaitTime;

    private float fallingTime;

    private Rigidbody2D playerRigid;

    private PlayerManager playerManager;
    
    public bool IsGround { set; get; }

    private void Awake()
    {
        playerRigid = InGameManager.Instance.PlayerDataContainer_readonly.PlayerRigid;

        playerManager = InGameManager.Instance.PlayerDataContainer_readonly._PlayerManager;

        fallingTime = 0f;
    }

    public void Jump()
    {
        IsGround = false;

        playerRigid.AddForce(this.transform.up * jumpSpeed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        if (!IsGround)
        {
            fallingTime += Time.deltaTime;

            if (fallingTime < checkWaitTime)
                return;

            if (!IsGround)
            {
                IsGround = Physics2D.OverlapCircle(this.transform.position, 0.1f, LayerMask.GetMask("Ground"));

                if (IsGround)
                {
                    IsGround = true;

                    fallingTime = 0f;

                    playerManager.Idle();
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawSphere(this.transform.position, 0.1f);
    }
}