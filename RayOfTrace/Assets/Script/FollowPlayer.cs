using UnityEngine;
using UniRx;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private bool followX = true;

    [SerializeField]
    private bool followY = true;

    private PlayerDataContainer container;

    private Transform playerTrans;

    private void Awake()
    {
        container = InGameManager.Instance.PlayerDataContainer_readonly;

        playerTrans = container.PlayerTrans;

        Observable.EveryUpdate()
            .Select(_ => new Vector3(followX ? playerTrans.position.x : this.transform.position.x,
                                             followY ? playerTrans.position.y : this.transform.position.y,
                                             this.transform.position.z))
            .DistinctUntilChanged()
            .Subscribe(position => this.transform.position = position);
    }
}