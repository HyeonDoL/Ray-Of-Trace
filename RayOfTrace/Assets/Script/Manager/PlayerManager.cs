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

    public bool Getjump()
    {
        return playerJump.IsGround;
    }
=======

    public bool IsGround { get { return playerJump.IsGround; } }

>>>>>>> da0649a37771bdfa32f79117242e0a8764250973

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