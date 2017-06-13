using System.Collections;
using UnityEngine;

public abstract class LightBehaviour : MonoBehaviour
{
    [SerializeField]
    protected Light light;

    [SerializeField]
    protected GameObject lightObject;

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

    public GameObject LightObject
    {
        get
        {
            return this.lightObject;
        }
    }

    public abstract IEnumerator Lighting();
}