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
    private GameObject HavingWhite;
    
    public GameObject NowCrash;
  //  public bool cangetwhite = false;
    public bool candeletecrash = false;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {       
        if (PlayerPrefs.GetInt(Prefstype.Item1Use, 1) == 1)// 포탈담는 버튼 눌렀는지 체크
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f);
                Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousepos.z = 0;
                if (hit)
                {
                    if (hit.transform.CompareTag("TeleportExit")&&!ingameButtonManager.IshaveWhite&& HavingWhite == null)
                    {
                     
                        HavingWhite = hit.transform.gameObject;
                        HavingWhite.SetActive(false);
                        ingameButtonManager.IshaveWhite = true;
                        PlayerPrefs.SetInt(Prefstype.Item1Use, 0);
                    }
                    else if(hit.transform.CompareTag("Crack") && ingameButtonManager.IshaveWhite&& candeletecrash)
                    {
                        HavingWhite = null;
                        NowCrash.SetActive(false);
                        ingameButtonManager.IshaveWhite = false;
                        PlayerPrefs.SetInt(Prefstype.Item1Use, 0);
                    }
                 
                    
                }
                else if (ingameButtonManager.IshaveWhite == true)
                {
                    HavingWhite.transform.position = mousepos;
                    HavingWhite.SetActive(true);
                    HavingWhite = null;
                    ingameButtonManager.IshaveWhite = false;
                    PlayerPrefs.SetInt(Prefstype.Item1Use, 0);
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