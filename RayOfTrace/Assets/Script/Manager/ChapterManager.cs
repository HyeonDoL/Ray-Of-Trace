using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour {

    [SerializeField]
    private NormalLight glowLight;
    [SerializeField]
    private RepeatLight dimLight;
    [SerializeField]
    private RepeatLight repeatLight;
    [SerializeField] private GameObject ChapterWindow;
    [SerializeField] private GameObject OptionWindow;
    [SerializeField] private GameObject ShopWindow;


    private IEnumerator ChangeWindow()
    {
        repeatLight.gameObject.SetActive(false);

        dimLight.LightIntensity = repeatLight.LightIntensity;
        yield return StartCoroutine(glowLight.Lighting());

       

     
    }
    public void OptionButton()
    {
        ChangeWindow();
        ChapterWindow.SetActive(false);
        OptionWindow.SetActive(true);
    }
    public void ShopButton()
    {
        ChangeWindow();
        ChapterWindow.SetActive(false);
        ShopWindow.SetActive(true);
    }
    public void BackButton()
    {
        ChangeWindow();
        OptionWindow.SetActive(false);
        ShopWindow.SetActive(false);
        ChapterWindow.SetActive(true);
       
    }
}
