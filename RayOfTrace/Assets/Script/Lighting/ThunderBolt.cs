using System.Collections;
using UnityEngine;

public class ThunderBolt : MonoBehaviour
{
    [SerializeField]
    private Light light;

    [SerializeField]
    private float time;

    public IEnumerator Lighting()
    {
        float t = 0f;

        while(t < 1f)
        {
            t += Time.deltaTime / time;

            light.enabled = true;

            yield return null;
        }

        light.enabled = false;
    }
}