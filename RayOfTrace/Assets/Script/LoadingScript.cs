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

    private float changeTime;
    private float linearTime;

    private int backgroundIndex;

    bool IsDone = false;
    float fTime = 0f;
    int m_chapternum;
    int m_istomain;
    AsyncOperation async_operation;

    void Start()
    {
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
                //currentTime = async_operation.progress;
                yield return true;
            }
        }
    }
}
