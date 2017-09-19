using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [SerializeField]
    private float dampTime = 0.15f;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 addPos;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 finalTarget = target.transform.position + addPos;

            Vector3 point = Camera.main.WorldToViewportPoint(finalTarget);
            Vector3 delta = finalTarget - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}