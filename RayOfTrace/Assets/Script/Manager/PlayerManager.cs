using UnityEngine;

public enum PlayerState
{
    Idle = 0,
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

    [SerializeField]
    private PlayerInteraction playerInteraction;

    [SerializeField]
    private PlayerStatus playerStatus;

    private BoxCollider2D m_playerBoxcollider;

    private void Awake()
    {
        IsDie = false;
    }

    public bool IsDie { get; private set; }
    public bool IsGround { get { return playerJump.IsGround; } }

    public void Idle()
    {
        playerJump.IsGround = true;
        playerAni.ChangeAni(PlayerState.Idle);
    }

    public void Move(Vector2 direction)
    {
        playerMove.Move(direction);
        
        playerAni.ChangeAni(PlayerState.Move);
    }

    public void Jump()
    {
        playerJump.Jump();

        playerAni.ChangeAni(PlayerState.Jump);
    }
    public void Throw()
    {
        playerAni.ChangeAni(PlayerState.ShadowItem);
    }
    public void Interaction()
    {
        playerInteraction.Interaction();
    }

    public void Damage(int value)
    {
        playerStatus.Hp = playerStatus.Hp - value;

        playerAni.ChangeAni(PlayerState.Damage);

        if (playerStatus.Hp <= 0)
            Die();

        Invoke("Idle", 0.5f);
    }
    private void Die()
    {
        playerAni.ChangeAni(PlayerState.Die);

        Invoke("CheckDie", 1.1f);
    }
    private void CheckDie()
    {
        IsDie = true;
    }
}