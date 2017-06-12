using System.Collections;
using UnityEngine;

public class ThunderBolt : LightBehaviour
{
    [SerializeField]
    private int lightingCount;

    [SerializeField]
    private float time;

    [SerializeField]
    private float delay;

    public override IEnumerator Lighting()
    {
        float t = 0f;

        for (int count = 0; count < lightingCount; count++)
        {
            LightObject.SetActive(true);

            while (t < 1f)
            {
                t += Time.deltaTime / time;

                yield return null;
            }

            t = 0f;

            LightObject.SetActive(false);

            yield return new WaitForSeconds(delay);
        }
    }
}