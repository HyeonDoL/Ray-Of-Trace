using System.Collections;
using UnityEngine;

public class NormalLight : LightBehaviour
{
    private enum NormalLightType
    {
        Glow,
        Dim
    }

    [SerializeField]
    private NormalLightType type;

    [SerializeField]
    private float maxIntensity;

    [SerializeField]
    private float minIntensity;

    [SerializeField]
    private float time;

    public override IEnumerator Lighting()
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