using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private ChapterManager chaterManager;
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
    [SerializeField]
    private Image fade;
    private int m_istomain;
    private float fades = 0f;
    private bool fadetrue = false;
    private void Awake()
    {
       
        m_istomain = PlayerPrefs.GetInt(Prefstype.IsToMain,0);
        StartCoroutine(repeatLight.Lighting());
    }

    private void Start()
    {
        chaterManager = this.GetComponent<ChapterManager>();
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
        {
            fadetrue = true;
            StartCoroutine(ChangeScene());
        }
        if (fadetrue) // fadein
        {
            if (fades < 1.0f)
            {
                fade.raycastTarget = true;
                fades += 0.01f;
                fade.color = new Color(0, 0, 0, fades);

            }
            else if (fades >= 1.0f)
            {
                ChapterWindow.SetActive(true);
                chaterManager.fadeOuttrue = true;
            }
        }
    }
 
    private IEnumerator ChangeScene()
    {
        repeatLight.gameObject.SetActive(false);
        normalLight.LightIntensity = repeatLight.LightIntensity;
       yield return StartCoroutine(normalLight.Lighting());
        
        TitleWindow.SetActive(false);
        repeatLight.gameObject.SetActive(true);
      
        BackGround.SetActive(true);
        

    }
}