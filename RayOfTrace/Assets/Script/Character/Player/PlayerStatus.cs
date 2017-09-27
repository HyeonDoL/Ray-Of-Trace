using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private const int maxHp = 100;

    public int Hp { get; set; }

    private void Awake()
    {
        Hp = maxHp;
    }
}