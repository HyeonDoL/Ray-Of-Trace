using System.Collections;
using UnityEngine;

public class RepeatLight : MonoBehaviour
{
    [SerializeField]
    private Light light;

    [SerializeField]
    private float maxIntensity;

    [SerializeField]
    private float time;

    public float LightIntensity
    {
        get
        {
            return this.light.intensity;
        }
        set
        {
            light.intensity = value;
        }
    }

    public IEnumerator Lighting()
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