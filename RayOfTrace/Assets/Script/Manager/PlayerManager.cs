using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMove playerMove;

    [SerializeField]
    private PlayerJump playerJump;

    public void Move(Vector2 direction)
    {
        playerMove.Move(direction);
    }

    public void Jump()
    {
        playerJump.Jump();
    }
}