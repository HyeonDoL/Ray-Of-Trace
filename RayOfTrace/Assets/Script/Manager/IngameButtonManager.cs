using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class IngameButtonManager : MonoBehaviour
{
    public static IngameButtonManager instance = null;
    public static IngameButtonManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("*Manager").AddComponent<IngameButtonManager>();
        }
    }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    private JoystickController m_joystickController;
    [SerializeField]
    private GameObject PauseWindow;
    [SerializeField]
    private GameObject Buttons;
    [SerializeField]
    private GameObject JumpActionButton;
    [SerializeField]
    private GameObject ItemRange;
    [SerializeField]
    private GameObject Joystick;
    [SerializeField]
    private GameObject Item1;
    [SerializeField]
    private GameObject Item2;
    [SerializeField]
    private GameObject Jem;
    [SerializeField]
    private Sprite Jump;
    [SerializeField]
    private Sprite Action;
 
    [SerializeField]
    private ItemRangeScript ItemRange_script;
    private Vector3 m_itemUsePosition;
    private int m_whatitem = 0;
    private bool m_JumpActionButton = false;
    private bool m_ItemButton1 = false;
    private bool m_ItemButton2 = false;
    private bool m_PauseButton = false;
    private bool m_istouchbutton = false;
    private bool m_isaction = false;
    private bool m_ItemButton1active = false;
    private bool m_ItemButton2active = false;
    private bool m_isitemUse = false;
    private bool m_isitemUsed = false;

    public bool IsAction
    {
        set
        {
            m_isaction = value;
        }
    }

    private bool m_ishaveJem = false;

    public SpriteState state;

    [SerializeField]
    private PlayerManager playerManager;
  
    private void Update()
    {
        if (!m_isaction)
        {
            if (Input.GetKeyDown(KeyCode.W)/* && playerManager.IsGround*/)
            {

                playerManager.Jump();


            }
            if (playerManager.IsGround)
            {
                JumpActionButton.GetComponent<Image>().sprite = state.highlightedSprite;
            }
            else
            {
                JumpActionButton.GetComponent<Image>().sprite = state.pressedSprite;
            }
        }
    }
    void Start()
    {
        playerManager = InGameManager.Instance.PlayerDataContainer_readonly._PlayerManager;

        init_buttonPos();
        var itemStream = Observable.EveryUpdate()
                .Where(_ => (Input.GetMouseButtonUp(0)|| Input.GetMouseButtonUp(1)) && 
                            m_whatitem !=0 &&
                            !m_PauseButton);
        var clickStream = Observable.EveryUpdate()
         .Where(_ => m_istouchbutton);
        var isAction = Observable.EveryUpdate();
        // 이미지 변경
        isAction
            .Where(_ => m_isaction)
            .Subscribe(_ =>
            {
                JumpActionButton.GetComponent<Image>().sprite = Action;
            });
        isAction
            .Where(_ => !m_isaction)
            .Subscribe(_ =>
            {
                JumpActionButton.GetComponent<Image>().sprite = Jump;
            });
        itemStream
            .Where(_=> !m_isitemUsed)
            .Subscribe(_ =>
            {
                ItemUse();
            });


        // 점프 , 액션 버튼 눌렀을때
        clickStream
            .Where(_ => m_JumpActionButton)
            .Subscribe(_ => {

                if (m_isaction)
                {
                    playerManager.Interaction();

                    //action
                    if (!m_ishaveJem)
                    {
                        //Fucking No jem
                        Jem.SetActive(true);
                        m_ishaveJem = true;
                    }
                    else
                    {
                        // clear
                    }
                }
                else
                {
                    playerManager.Jump();
                }

                m_JumpActionButton = false;
                m_istouchbutton = false;
            });

        // 아이템1 버튼 눌렀을때
        clickStream
         .Where(_ => m_ItemButton1)
         .Subscribe(_ => {
             //item1
             if (!m_ItemButton1active) // 활성화
             {
                 ItemRange.SetActive(true);
                 Joystick.SetActive(false);
                 JumpActionButton.SetActive(false);
                 Item1.SetActive(false);
                 Item2.SetActive(false);
                 m_ItemButton1active = true;
                 m_whatitem = 1;
             }
             //else if (m_ItemButton1active == true)
             //{

             //    ItemRange.SetActive(false);
             //    Joystick.SetActive(true);
             //    JumpActionButton.SetActive(true);
             //    Item1.SetActive(true);
             //    Item2.SetActive(true);
             //    m_ItemButton1active = false;
             //    m_whatitem = 0;
             //}
             m_ItemButton1 = false;
             m_istouchbutton = false;
         });

        // 아이템2 버튼 눌렀을때
        clickStream
         .Where(_ => m_ItemButton2)
         .Subscribe(_ => {
             //item2
             if (!m_ItemButton2active)
             {
                 ItemRange.SetActive(true);
                 Joystick.SetActive(false);
                 JumpActionButton.SetActive(false);
                 Item1.SetActive(false);
                 Item2.SetActive(false);
                 m_ItemButton2active = true;
                 m_whatitem = 2;
             }
             //else if (m_ItemButton2active == true)
             //{
             //    ItemRange.SetActive(false);
             //    Joystick.SetActive(true);
             //    JumpActionButton.SetActive(true);
             //    Item1.SetActive(true);
             //    Item2.SetActive(true);
             //    m_ItemButton2active = false;
             //    m_whatitem = 0;
             //}

             m_ItemButton2 = false;
             m_istouchbutton = false;
         });
        // 일시정지 버튼 눌렀을때
        clickStream
         .Where(_ => m_PauseButton)
         .Subscribe(_ => {

             PauseWindow.SetActive(true);
             Buttons.SetActive(false);
             Time.timeScale = 0;
             m_istouchbutton = false;
         });
        // 게임으로 돌아가기
        clickStream
         .Where(_ => !m_PauseButton)
         .Subscribe(_ => {
            
             PauseWindow.SetActive(false);
             Buttons.SetActive(true);
             m_istouchbutton = false;
             Time.timeScale = 1;
            
         });



       
    }
    
    private void ItemUse()
    {
        // 아이템 사용되는곳
        if (m_whatitem !=0)
        {
            ItemRange_script.CastRay();
            m_itemUsePosition = ItemRange_script.ItemPosition();
            m_isitemUse = ItemRange_script.ison;
            //item1
            if (m_whatitem == 1 && m_isitemUse)  //item1 use
            {
                Debug.Log(m_itemUsePosition);
                ItemUsed();
            }
            else if (m_whatitem == 2 && m_isitemUse) // item2 use
            {
                Debug.Log(m_itemUsePosition);
                playerManager.Throw();
                ItemUsed();
            }
            else if (!m_isitemUse)
                ItemUsed();
        }

    }
    private void ItemUsed()
    {
        m_isitemUse = false;
        ItemRange_script.ison = false;
        m_ItemButton1active = false;
        m_ItemButton2active = false;
        ItemRange.SetActive(false);
        Joystick.SetActive(true);
        Item1.SetActive(true);
        Item2.SetActive(true);
        JumpActionButton.SetActive(true);
        m_whatitem = 0;
        m_joystickController.InitPos();
    }
    public void Ison_jumpaction()
    {
        m_JumpActionButton = true;
        m_istouchbutton = true;
    }
    public void Ison_item1()
    {
        m_ItemButton1 = true;
        m_istouchbutton = true;

    }
    public void Ison_item2()
    {
        m_ItemButton2 = true;
        m_istouchbutton = true;

    }
    public void Ison_pausebutton()
    {
        m_PauseButton = true;
        m_istouchbutton = true;
        ItemUsed();
    }
    public void Ison_closepausebutton()
    {
        m_PauseButton = false;
        m_istouchbutton = true;
        m_joystickController.InitPos();
    }
    public void Ison_retrybutton()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt(Prefstype.IsToMain, 0);
        SceneChange.Change(SceneType.Loading);
    }
    public void Ison_tomainscene()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt(Prefstype.IsToMain, 1);
        SceneChange.Change(SceneType.Loading);
    }
    public void Disable_ItemRange()
    {
        m_ItemButton1active = false;
        m_ItemButton2active = false;
        m_whatitem = 0;
    }
    public void ClearAnimation()
    {
        playerManager.Idle();
    }
    private void init_buttonPos()
    {
        Joystick.transform.localPosition = 
            new Vector3(PlayerPrefs.GetInt(Prefstype.JoystickxPos, -624),
                        PlayerPrefs.GetInt(Prefstype.JoystickyPos, -284), 0.0f);
        JumpActionButton.transform.localPosition = 
            new Vector3(PlayerPrefs.GetInt(Prefstype.JumpButtonxPos, 634),
                        PlayerPrefs.GetInt(Prefstype.JumpButtonyPos, -300), 0.0f);
        Item1.transform.localPosition = 
            new Vector3(PlayerPrefs.GetInt(Prefstype.Item1xPos, 439),
                        PlayerPrefs.GetInt(Prefstype.Item1yPos, -175), 0.0f);
        Item2.transform.localPosition = 
            new Vector3(PlayerPrefs.GetInt(Prefstype.Item2xPos, 629),
                        PlayerPrefs.GetInt(Prefstype.Item2yPos, -61), 0.0f);
    }


}

