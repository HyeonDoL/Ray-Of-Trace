using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour {

   
    [SerializeField] private NormalLight normalLight;
    [SerializeField] private RepeatLight repeatLight;
    [SerializeField] private MoveButtonScript m_Movebuttonscript;
    [SerializeField] private GameObject ChapterWindow;
    [SerializeField] private GameObject OptionWindow;
    [SerializeField] private GameObject ShopWindow;
    [SerializeField] private GameObject SoundWindow;
    [SerializeField] private GameObject MoveWindow;
    [SerializeField] private GameObject MoveButton;

    [SerializeField] private Text Money;

    private int money;
    private void Start()
    {
       
        money = PlayerPrefs.GetInt(Prefstype.Money,999999999);
        Money.text = "" + money;
    }
    private IEnumerator ChangeWindow()
    {

        repeatLight.gameObject.SetActive(false);

        normalLight.LightIntensity = repeatLight.LightIntensity;

        yield return StartCoroutine(normalLight.Lighting());

    }
    public void OptionButton()
    {

        ChapterWindow.SetActive(false);
        OptionWindow.SetActive(true);
    }
    public void ShopButton()
    {

        ChapterWindow.SetActive(false);
        ShopWindow.SetActive(true);
    }
    public void BackButton()
    {

        OptionWindow.SetActive(false);
        ShopWindow.SetActive(false);
        ChapterWindow.SetActive(true);

    }
    public void OptionBackButton()
    {
        SoundWindow.SetActive(false);
        MoveWindow.SetActive(false);
        MoveButton.SetActive(false);
        OptionWindow.SetActive(true);
    }
    public void ChpaterButton(int index)
    {
        ChangeWindow();
        PlayerPrefs.SetInt(Prefstype.ChapterNum, index);
        SceneChange.Change(SceneType.Loading);
    }
    public void BuySkin(int index)
    {

    }
    public void SoundOption()
    {
        OptionWindow.SetActive(false);
        SoundWindow.SetActive(true);
    }
    public void MoveOption()
    {
        OptionWindow.SetActive(false);
        MoveWindow.SetActive(true);
        MoveButton.SetActive(true);
        m_Movebuttonscript.Setjoypadposition();
    }
    public void Init_JoyPad()
    {
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
        m_Movebuttonscript.ChangeButtonPos();
        m_Movebuttonscript.Setjoypadposition();
    }
   
}
