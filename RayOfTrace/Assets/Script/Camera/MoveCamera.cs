using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed = 10f;

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * cameraSpeed * Time.deltaTime,
                            Input.GetAxis("Vertical") * cameraSpeed * Time.deltaTime, 0);

    }
}
