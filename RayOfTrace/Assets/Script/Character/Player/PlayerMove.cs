using UnityEngine;

using UniRx;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private PlayerDataContainer container;

    [SerializeField]
    private float speed;

    private Rigidbody2D playerRigid;

    private void Awake()
    {
        playerRigid = container.PlayerRigid;

        var horizontalStream = Observable.EveryUpdate()
            .Select(_ => Input.GetAxis("Horizontal"))
            .Select(horizontal => horizontal == 0 ? 0 : (horizontal > 0 ? 1 : -1));

        var moveStream = horizontalStream
            .Select(horizontal => new Vector2(horizontal * speed * Time.deltaTime, 0))
            .Subscribe(movement => playerRigid.MovePosition((Vector2)transform.position + movement));

        var flipStream = horizontalStream
            .Where(horizontal => horizontal != 0)
            .DistinctUntilChanged()
            .Subscribe(_ =>
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x * -1,
                                                                    this.transform.localScale.y,
                                                                    this.transform.localScale.z);
            });
    }
}