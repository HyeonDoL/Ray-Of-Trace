using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScript : MonoBehaviour
{
    [SerializeField]
    private float minimumTime = 3f;

    [SerializeField]
    private SpriteRenderer[] backgrounds;

    [SerializeField]
    private Image fade;

    public bool fadeOuttrue = false;
    public bool fadeIntrue = false;
    private float changeTime;
    private float linearTime;
    private float fades = 1.0f;

    private int backgroundIndex;

    bool IsDone = false;
    float fTime = 0f;
    int m_chapternum;
    int m_istomain;
    AsyncOperation async_operation;

    void Start()
    {
        fadeOuttrue = true;
        m_chapternum = PlayerPrefs.GetInt(Prefstype.ChapterNum);
        m_istomain = PlayerPrefs.GetInt(Prefstype.IsToMain);
        if(m_istomain == 0)
            StartCoroutine(StartLoad(SceneType.InGame));
        else if (m_istomain == 1)
            StartCoroutine(StartLoad(SceneType.Title));

        changeTime = minimumTime / backgrounds.Length;
    }

    void Update()
    {
        if (fadeIntrue) // fadein
        {
            if (fades < 1.0f)
            {
                fades += 0.02f;
                fade.color = new Color(0, 0, 0, fades);

            }
            else if (fades >= 1.0f)
            {
                fadeIntrue = false;
            }
        }
        else if (fadeOuttrue) // fadeout
        {

            if (fades >= 0)
            {
                fades -= 0.01f;
                fade.color = new Color(0, 0, 0, fades);

            }
            else if (fades <= 0)
            {
              
                fadeOuttrue = false;
            }
        }
        fTime += Time.deltaTime;

        if (fTime >= minimumTime)
        {
          
            async_operation.allowSceneActivation = true;
        }

        SmoothChangeBackground();
    }

    private void SmoothChangeBackground()
    {
        backgroundIndex = (int)(fTime / changeTime);

        if (backgroundIndex + 1 >= backgrounds.Length)
            return;

        linearTime = Mathf.InverseLerp(0.0f + (changeTime * backgroundIndex), 0.0f + (changeTime * (backgroundIndex + 1)), fTime);

        backgrounds[backgroundIndex + 1].color = new Color(1f, 1f, 1f, linearTime);
    }

    public IEnumerator StartLoad(string strSceneName)
    {       
        async_operation = SceneManager.LoadSceneAsync(strSceneName); 
       
        async_operation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (async_operation.progress < 0.9f)
            {
                fadeIntrue = true;
                yield return true;
            }
        }
    }
}
