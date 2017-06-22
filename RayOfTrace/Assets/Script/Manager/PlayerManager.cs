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

    private BoxCollider2D m_playerBoxcollider;
  
<<<<<<< HEAD
    public bool IsGround { get { return playerJump.IsGround; } }

=======
    public bool Getjump()
    {
        return playerJump.IsGround;
    }
>>>>>>> e402a8b2a712da88ba7b0a7ee9e17b2c7073d55b
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
}