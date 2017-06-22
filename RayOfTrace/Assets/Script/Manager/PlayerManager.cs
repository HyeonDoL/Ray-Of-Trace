using UnityEngine;

public enum PlayerState
{
    Idle,
    Move,
    Jump,
    Damage,
    LightItem,
    ShadowItem,
    Die
}

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMove playerMove;

    [SerializeField]
    private PlayerJump playerJump;

    [SerializeField]
    private PlayerAnimation playerAni;
    private BoxCollider2D m_playerBoxcollider;
    [SerializeField] public bool m_isground = false;
    public void Start()
    {
        m_playerBoxcollider = this.GetComponent<BoxCollider2D>();
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_isground = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_isground = false;
        }

    }
    public void Move(Vector2 direction)
    {
        if(direction.x < 0 )
        {
            this.transform.localScale = new Vector3 (-0.13f,0.13f);
        }
        else
        {
            this.transform.localScale = new Vector3(0.13f, 0.13f);
        }
        playerMove.Move(direction);
        
        playerAni.ChangeAni(PlayerState.Move);
    }

    public void Jump()
    {
        playerJump.Jump();

        playerAni.ChangeAni(PlayerState.Jump);
    }
}