using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScript : MonoBehaviour
{

    public Slider slider;
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
    }

    void Update()
    {
        fTime += Time.deltaTime;
        slider.value = fTime;

        if (fTime >= 2)
        {
            async_operation.allowSceneActivation = true;
        }
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
                slider.value = async_operation.progress;
                yield return true;
            }
        }
    }


}
