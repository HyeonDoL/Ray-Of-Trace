using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour {

   
    [SerializeField] private NormalLight normalLight;
    [SerializeField] private RepeatLight repeatLight;
    [SerializeField] private MoveButtonScript m_Movebuttonscript;
    [SerializeField] private GameObject BackGround;
    [SerializeField] private GameObject ChapterWindow;
    [SerializeField] private GameObject ChapterButton;
    [SerializeField] private GameObject OptionWindow;
    [SerializeField] private GameObject ShopWindow;
    [SerializeField] private GameObject SoundWindow;
    [SerializeField] private GameObject MoveWindow;
    [SerializeField] private GameObject MoveButton;
    [SerializeField] private GameObject MainWindow;
    [SerializeField] private GameObject AcheivementWindow;
    [SerializeField] private TitleManager titlemanager;
    [SerializeField] private Text Money;
    [SerializeField] private Image fade;
    [SerializeField] private Slider Bgm;
    [SerializeField] private Slider Sound;
    [SerializeField] private Button[] ChapterButtons;
    private int money;
  
    private float fades= 1.0f;

    private int pos = 0;
    public bool fadeOuttrue = false;
    public bool fadeIntrue = false;
    public int PageNum;
    public int pages;
    public int speed;
    private void Start()
    {
     
        money = PlayerPrefs.GetInt(Prefstype.Money,999999999);
        pages = 1;
        Money.text = "" + money;
        titlemanager = this.GetComponent<TitleManager>();
        if (PlayerPrefs.GetInt(Prefstype.C2Unlock) == 1)
            ChapterButtons[0].interactable = true;
        if (PlayerPrefs.GetInt(Prefstype.C3Unlock) == 1)
            ChapterButtons[1].interactable = true;
       // if (PlayerPrefs.GetInt(Prefstype.C4Unlock) == 1)
        //    ChapterButtons[3].interactable = true;
    }
    private void Update()
    {
        PlayerPrefs.SetFloat(Prefstype.BgmVol, Bgm.value);
        PlayerPrefs.SetFloat(Prefstype.SoundVol, Sound.value);
        ChapterButton.transform.localPosition = Vector3.MoveTowards(ChapterButton.transform.localPosition, new Vector3(-20 * (pages - 1), 0, 0), speed * Time.deltaTime);
        if (fadeIntrue)
        {
            if (fades < 1.0f)
            {
                fade.raycastTarget = true;
                fades += 0.01f;
                fade.color = new Color(0, 0, 0, fades);
            }
            else if (fades >= 1.0f)
            {
                SceneChange.Change(SceneType.Loading);
                fadeIntrue = false;
            }
           
        }
        else if (fadeOuttrue) // fadeout
        {
           
            if (fades >= 0)
            {
                titlemanager.enabled = false;
                fade.raycastTarget = true;
                fades -= 0.01f;
                fade.color = new Color(0, 0, 0, fades);
            
            }
            else if (fades <= 0)
            {
                fade.raycastTarget = false;
                fadeOuttrue = false;
            }
        }
    }
    private IEnumerator ChangeWindow()
    {

        repeatLight.gameObject.SetActive(false);

        normalLight.LightIntensity = repeatLight.LightIntensity;

        yield return StartCoroutine(normalLight.Lighting());

    }
   
    public void OptionButton()
    {
        SoundManager.instance.PlaySound();
        MainWindow.SetActive(false);
        OptionWindow.SetActive(true);
    }
    public void StartBack()
    {
        SoundManager.instance.PlaySound();
        ChapterWindow.SetActive(false);
        MainWindow.SetActive(true);
        BackGround.SetActive(true);
    }
    public void ShopButton()
    {
        SoundManager.instance.PlaySound();
        MainWindow.SetActive(false);
        ShopWindow.SetActive(true);
    }
    public void BackButton()
    {

        SoundManager.instance.PlaySound();
        OptionWindow.SetActive(false);
        ShopWindow.SetActive(false);
        MainWindow.SetActive(true);

    }
    public void OptionBackButton()
    {
        SoundManager.instance.PlaySound();
        SoundWindow.SetActive(false);
        MoveWindow.SetActive(false);
        MoveButton.SetActive(false);
        OptionWindow.SetActive(true);
    }
    public void ChpaterButton(int index)
    {
        SoundManager.instance.PlaySound();
        PlayerPrefs.SetInt(Prefstype.ChapterNum, index);
        fadeIntrue = true;
    }
    public void BuySkin(int index)
    {

    }
    public void SoundOption()
    {
        SoundManager.instance.PlaySound();
        OptionWindow.SetActive(false);
        SoundWindow.SetActive(true);
    }
    public void MoveOption()
    {
        SoundManager.instance.PlaySound();
        OptionWindow.SetActive(false);
        MoveWindow.SetActive(true);
        MoveButton.SetActive(true);
        m_Movebuttonscript.Setjoypadposition();
    }
    public void StartButton()
    {
        SoundManager.instance.PlaySound();
        BackGround.SetActive(false);
        MainWindow.SetActive(false);
        ChapterWindow.SetActive(true);
    }
    public void Init_JoyPad()
    {
        SoundManager.instance.PlaySound();
        PlayerPrefs.SetInt(Prefstype.JoystickxPos, -624);
        PlayerPrefs.SetInt(Prefstype.JoystickyPos, -284);
        PlayerPrefs.SetInt(Prefstype.JumpButtonxPos, 634);
        PlayerPrefs.SetInt(Prefstype.JumpButtonyPos, -300);
        PlayerPrefs.SetInt(Prefstype.Item1xPos, 439);
        PlayerPrefs.SetInt(Prefstype.Item1yPos, -175);
        PlayerPrefs.SetInt(Prefstype.Item2xPos, 629);
        PlayerPrefs.SetInt(Prefstype.Item2yPos, -61);
        m_Movebuttonscript.Setjoypadposition();
    }
    public void Set_JoyPad()
    {
        SoundManager.instance.PlaySound();
        m_Movebuttonscript.ChangeButtonPos();
        m_Movebuttonscript.Setjoypadposition();
    }
    public void AcheivementButton()
    {
        SoundManager.instance.PlaySound();
        AcheivementWindow.SetActive(true);
    }
    public void AcheivementBack()
    {
        SoundManager.instance.PlaySound();
        AcheivementWindow.SetActive(false);
    }
    public void LeftButton()
    {
        SoundManager.instance.PlaySound();
        if (pages > 1)
        {
            pages--;
          }
    }
    public void RightButton()
    {
        SoundManager.instance.PlaySound();
        if (pages < PageNum)
        {
            pages++;
         
        }
    }
}
