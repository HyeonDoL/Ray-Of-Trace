using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;

    [SerializeField]
    private MeshRenderer mr;

    [SerializeField]
    private Color testColor = Color.white;

    [SerializeField]
    private float testAlpha;

    [SerializeField]
    private float time = 0.5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            StartCoroutine(Tween.TweenTransform.Position(this.transform, _object.transform.position, time));

        if (Input.GetKeyDown(KeyCode.W))
            StartCoroutine(Tween.TweenTransform.Rotation(this.transform, _object.transform.rotation, time));

        if (Input.GetKeyDown(KeyCode.E))
            StartCoroutine(Tween.TweenTransform.LocalScale(this.transform, _object.transform.localScale, time));

        if (Input.GetKeyDown(KeyCode.Z))
            StartCoroutine(Tween.TweenMaterial.TweenColor(mr.material, testColor, time));

        if (Input.GetKeyDown(KeyCode.C))
            StartCoroutine(Tween.TweenMaterial.TweenAlpha(mr.material, testAlpha, time));
    }
}