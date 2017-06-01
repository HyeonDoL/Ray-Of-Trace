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
    private void Awake()
    {
        StartCoroutine(repeatLight.Lighting());
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

       // SceneChange.Change(SceneType.InGame);
    }
}