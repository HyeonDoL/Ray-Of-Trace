using System.Collections;
using UnityEngine;

public class ThunderBolt : MonoBehaviour
{
    [SerializeField]
    private Light light;

    [SerializeField]
    private int lightingCount;

    [SerializeField]
    private float time;

    [SerializeField]
    private float delay;

    public IEnumerator Lighting()
    {
        float t = 0f;

        for (int count = 0; count < lightingCount; count++)
        {
            light.enabled = true;

            while (t < 1f)
            {
                t += Time.deltaTime / time;

                yield return null;
            }

            t = 0f;

            light.enabled = false;

            yield return new WaitForSeconds(delay);
        }
    }
}