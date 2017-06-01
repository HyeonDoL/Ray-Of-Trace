using System.Collections;
using UnityEngine;

public abstract class LightBehaviour : MonoBehaviour
{
    [SerializeField]
    protected Light light;

    [SerializeField]
    private bool playOnAwake;

    private void Awake()
    {
        if (playOnAwake)
            StartCoroutine(Lighting());
    }

    public float LightIntensity
    {
        get
        {
            return this.light.intensity;
        }
        set
        {
            this.light.intensity = value;
        }
    }

    public abstract IEnumerator Lighting();
}