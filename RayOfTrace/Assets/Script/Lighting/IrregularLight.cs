using System.Collections;
using UnityEngine;

public class IrregularLight : LightBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    private int blinkProbability;

    [SerializeField]
    private int maxBlinkCount;

    [SerializeField]
    private float delay;

    [SerializeField]
    private float blinkDelay;

    public override IEnumerator Lighting()
    {
        while(true)
        {
            int random = Random.Range(0, 100) + 1;

            if(random > blinkProbability)
            {
                int randomCount = Random.Range(0, maxBlinkCount) + 1;

                for (int count = 0; count < randomCount; count++)
                {
                    light.enabled = false;

                    yield return new WaitForSeconds(blinkDelay);

                    light.enabled = true;

                    yield return new WaitForSeconds(blinkDelay);
                }
            }

            yield return new WaitForSeconds(delay);
        }
    }
}