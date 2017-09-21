using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private static InGameManager instance = null;
    public static InGameManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("*Manager").AddComponent<InGameManager>();
        }
    }

    [SerializeField]
    private PlayerDataContainer playerDataContainer;
    [SerializeField]
    private IngameButtonManager ingameButtonManager;

    private List<Transform> teleportExitTransList = new List<Transform>();

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (ingameButtonManager.WhatItemUse == 1)// 포탈담는 버튼 눌렀는지 체크
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f);

                if (hit)
                {
                    // TODO : 현재 포탈을 가지고 있는지 없는지 판별
                    // IshaveWhite 로 가져오셈 트루가 가지고 있는거임
                    if (hit.transform.CompareTag("TeleportExit"))
                    {
                        // TODO : 포탈 연동
                        ingameButtonManager.IshaveWhite = false;
                    }
                    
                }
                ingameButtonManager.ItemUsed();
            }
        }
    }

    public PlayerDataContainer PlayerDataContainer_readonly { get { return playerDataContainer; } }

    public void SetTeleportExitTrans(Transform teleportExitTrans)
    {
        teleportExitTransList.Add(teleportExitTrans);
    }
    public void RemoveTeleportExitTrans(Transform teleportExitTrans)
    {
        teleportExitTransList.Remove(teleportExitTrans);
    }
    
    public List<Transform> GetTeleportExitTransList()
    {
        return teleportExitTransList;
    }
}