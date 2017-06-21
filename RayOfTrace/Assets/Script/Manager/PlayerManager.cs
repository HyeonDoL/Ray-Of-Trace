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