using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Rigidbody2D playerRigid;

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

    public Transform PlayerTrans
    {
        get
        {
            return this.player.transform;
        }
    }

    public Rigidbody2D PlayerRigid
    {
        get
        {
            return this.playerRigid;
        }
    }
}