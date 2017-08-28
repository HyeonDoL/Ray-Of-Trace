using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool IsCrystal
    {
        set
        {
            IngameButtonManager.Instance.IsHaveJem = value;            
        }
        get
        {
            return IngameButtonManager.Instance.IsHaveJem;
        }
    }

    private void Awake()
    {
        IsCrystal = false;
    }
}