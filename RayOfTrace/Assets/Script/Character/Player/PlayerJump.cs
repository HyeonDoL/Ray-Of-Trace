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

            RaycastHit2D hitInfo;

            hitInfo = Physics2D.Raycast(this.transform.up * -0.1f, Vector2.down, 0.01f);

            Debug.Log(hitInfo.transform.name);

            if(hitInfo.transform.CompareTag("Ground"))
            {
                IsGround = true;

                fallingTime = 0f;

                playerManager.Idle();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(this.transform.up * -1.5f, Vector2.down);
    }
}