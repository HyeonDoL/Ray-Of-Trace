using System.Collections;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private NormalLight normalLight;
    [SerializeField]
    private RepeatLight repeatLight;
    [SerializeField]
    private GameObject ChapterWindow;
    [SerializeField]
    private GameObject TitleWindow;
    [SerializeField]
    private GameObject BackGround;

    private int m_istomain;
    private void Awake()
    {
        m_istomain = PlayerPrefs.GetInt(Prefstype.IsToMain,0);
        StartCoroutine(repeatLight.Lighting());
    }

    private void Start()
    {
        if (m_istomain == 1)
        {
            PlayerPrefs.SetInt(Prefstype.IsToMain, 0);
            TitleWindow.SetActive(false);
            repeatLight.gameObject.SetActive(true);
            ChapterWindow.SetActive(true);
            BackGround.SetActive(true);
            this.gameObject.GetComponent<TitleManager>().enabled = false;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        repeatLight.gameObject.SetActive(false);
        normalLight.LightIntensity = repeatLight.LightIntensity;
       yield return StartCoroutine(normalLight.Lighting());
        
        TitleWindow.SetActive(false);
        repeatLight.gameObject.SetActive(true);
        ChapterWindow.SetActive(true);
        BackGround.SetActive(true);
        this.gameObject.GetComponent<TitleManager>().enabled= false;

    }
}