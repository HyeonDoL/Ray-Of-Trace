using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class IngameButtonManager : MonoBehaviour
{

    [SerializeField]
    private GameObject PauseWindow;
    [SerializeField]
    private GameObject Buttons;
    [SerializeField]
    private GameObject JumpActionButton;
    [SerializeField]
    private Sprite Jump;
    [SerializeField]
    private Sprite Action;

    private bool m_JumpActionButton = false;
    private bool m_ItemButton1 = false;
    private bool m_ItemButton2 = false;
    private bool m_PauseButton = false;
    private bool m_istouchbutton = false;
    private bool m_isaction = false;
    void Start()
    {
        var clickStream = Observable.EveryUpdate()
         .Where(_ => m_istouchbutton);
        var isAction = clickStream;

        // 이미지 변경
        isAction
            .Where(_ => m_isaction == true)
            .Subscribe(_ =>
            {
                JumpActionButton.GetComponent<Image>().sprite = Action;
            });
        isAction
            .Where(_ => m_isaction == false)
            .Subscribe(_ =>
            {
                JumpActionButton.GetComponent<Image>().sprite = Jump;
            });



        // 점프 , 액션 버튼 눌렀을때
        clickStream
            .Where(_ => m_JumpActionButton == true)
            .Subscribe(_ => {

                if (m_isaction)
                {
                        //action
                    }
                else
                {
                        //jump
                    }

                m_JumpActionButton = false;
                m_istouchbutton = false;
            });

        // 아이템1 버튼 눌렀을때
        clickStream
         .Where(_ => m_ItemButton1 == true)
         .Subscribe(_ => {
                 //item1

                 m_ItemButton1 = false;
             m_istouchbutton = false;
         });

        // 아이템2 버튼 눌렀을때
        clickStream
         .Where(_ => m_ItemButton2 == true)
         .Subscribe(_ => {
                 //item2

                 m_ItemButton2 = false;
             m_istouchbutton = false;
         });

        // 일시정지 버튼 눌렀을때
        clickStream
         .Where(_ => m_PauseButton == true)
         .Subscribe(_ => {

             PauseWindow.SetActive(true);
             Buttons.SetActive(false);
             Time.timeScale = 0;
             m_istouchbutton = false;
         });
        // 게임으로 돌아가기
        clickStream
         .Where(_ => m_PauseButton == false)
         .Subscribe(_ => {

             PauseWindow.SetActive(false);
             Buttons.SetActive(true);
             Time.timeScale = 1;
             m_istouchbutton = false;
         });




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
    }
    public void Ison_closepausebutton()
    {
        m_PauseButton = false;
        m_istouchbutton = true;
    }
    public void Ison_retrybutton()
    {

    }
    public void Ison_tomainscene()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("IsTomain", 1);
        SceneChange.Change(SceneType.Loading);
    }
}
