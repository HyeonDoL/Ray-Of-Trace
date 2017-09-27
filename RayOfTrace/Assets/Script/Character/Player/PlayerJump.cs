using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{
   
    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private float checkWaitTime;

    private float fallingTime;

    private float jumptime;
    private Rigidbody2D playerRigid;

    private PlayerManager playerManager;
    [SerializeField]
    private Button jumpbutton;
    public bool IsGround { set; get; }

    private void Awake()
    {
        playerRigid = InGameManager.Instance.PlayerDataContainer_readonly.PlayerRigid;

        playerManager = InGameManager.Instance.PlayerDataContainer_readonly._PlayerManager;

        fallingTime = 0f;
        jumptime = 0f;
    }

    public void Jump()
    {
        IsGround = false;
        jumptime = 0;
        playerRigid.AddForce(this.transform.up * jumpSpeed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        jumptime += Time.deltaTime;
        if (jumptime < 0.8f)
            jumpbutton.interactable = false;
        else
            jumpbutton.interactable = true;
        if (!IsGround)
        {
            fallingTime += Time.deltaTime;
         

            if (fallingTime < checkWaitTime)
                return;

            if (!IsGround)
            {
                IsGround = Physics2D.OverlapCircle(this.transform.position - new Vector3(0, 0.1f), 0.1f, LayerMask.GetMask("Ground"));
                
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

        Gizmos.DrawSphere(this.transform.position - new Vector3(0, 0.1f), 0.1f);
    }
}