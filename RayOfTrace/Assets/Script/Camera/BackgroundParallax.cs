using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour
{
    public Transform[] backgrounds;       
    public float parallaxScale;                
    public float parallaxReductionFactor;  
    public float smoothing;                   


    private Transform cam;                   
    private Vector3 previousCamPos;                                     


    void Awake()
    {
        cam = Camera.main.transform;
    }


    void Start()
    {
        previousCamPos = cam.position;
    }


    void Update()
    {
        float parallax = (previousCamPos.x - cam.position.x) * parallaxScale;

        for (int count = 0; count < backgrounds.Length; count++)
        {
            float backgroundTargetPosX = backgrounds[count].position.x + parallax * (count * parallaxReductionFactor + 1);

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[count].position.y, backgrounds[count].position.z);

            backgrounds[count].position = Vector3.Lerp(backgrounds[count].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }
}
