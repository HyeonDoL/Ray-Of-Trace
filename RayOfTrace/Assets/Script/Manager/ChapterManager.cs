using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour {

    [SerializeField]
    private NormalLight glowLight;
    [SerializeField]
    private NormalLight dimLight;
    [SerializeField]
    private NormalLight normalLight;
    [SerializeField]
    private RepeatLight repeatLight;

    [SerializeField] private GameObject ChapterWindow;
    [SerializeField] private GameObject OptionWindow;
    [SerializeField] private GameObject ShopWindow;


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
    public void ChpaterButton(int index)
    {
        ChangeWindow();
        PlayerPrefs.SetInt("ChapterNum", index);
        SceneChange.Change(SceneType.Loading);
    }
}
