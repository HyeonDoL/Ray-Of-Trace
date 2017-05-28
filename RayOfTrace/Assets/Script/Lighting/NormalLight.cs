using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLight : MonoBehaviour
{
    private enum NormalLightType
    {
        Glow,
        Dim
    }

    [SerializeField]
    private Light light;

    [SerializeField]
    private NormalLightType type;

    [SerializeField]
    private float maxIntensity;

    [SerializeField]
    private float minIntensity;

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
        float t = 0f;

        float start = light.intensity;
        float end;

        if (type == NormalLightType.Glow)
            end = maxIntensity;

        else
            end = minIntensity;

        while(t < 1f)
        {
            t += Time.deltaTime / time;

            light.intensity = Mathf.Lerp(start, end, t);

            yield return null;
        }
    }
}