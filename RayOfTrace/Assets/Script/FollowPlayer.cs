using UnityEngine;
using UniRx;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private PlayerDataContainer container;

    private Transform playerTrans;
    
    private void Awake()
    {
        playerTrans = container.PlayerTrans;

        Observable.EveryUpdate()
            .Select(_ => new Vector3(playerTrans.position.x, playerTrans.position.y, this.transform.position.z))
            .DistinctUntilChanged()
            .Subscribe(position => this.transform.position = position);
    }
}