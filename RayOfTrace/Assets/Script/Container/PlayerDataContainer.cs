using UnityEngine;

public class PlayerDataContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Rigidbody2D playerRigid;

    [SerializeField]
    private PlayerManager manager;

    public GameObject Player
    {
        get
        {
            return this.player;
        }
        set
        {
            player = value;
        }
    }

    public Transform PlayerTrans { get { return player.transform; } }

    public Rigidbody2D PlayerRigid { get { return playerRigid; } }

    public PlayerManager _PlayerManager { get { return manager; } }
}