using System.Collections;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private NormalLight normalLight;

    [SerializeField]
    private RepeatLight repeatLight;

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

        SceneChange.Change(SceneType.InGame);
    }
}