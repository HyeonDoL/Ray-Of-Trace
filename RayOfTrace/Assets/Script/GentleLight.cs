using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GentleLight : MonoBehaviour
{
    [SerializeField]
    private Light light;

    [SerializeField]
    private float startIntensity;

    [SerializeField]
    private float maxIntensity;

    [SerializeField]
    private float time;

    private void Awake()
    {
        light.intensity = startIntensity;

        StartCoroutine(GentleLighting());
    }

    private IEnumerator GentleLighting()
    {
        int isLighting = 1;

        while(true)
        {
            float t = 0f;

            float start = light.intensity;

            float end = start + maxIntensity * isLighting;

            while (t < 1f)
            {
                t += Time.deltaTime / time;

                light.intensity = Mathf.Lerp(start, end, t);

                yield return null;
            }

            isLighting = isLighting * -1;
        }
    }
}