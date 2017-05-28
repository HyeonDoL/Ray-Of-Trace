using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private ThunderBolt thunder;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(thunder.Lighting());
    }
}