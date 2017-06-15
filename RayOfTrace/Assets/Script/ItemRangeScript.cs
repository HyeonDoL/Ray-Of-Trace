using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRangeScript : MonoBehaviour {

    private GameObject target;
    private RaycastHit hit;
    private Ray ray;
  
    void CastRay()
    {
        target = null;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 
        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
        {

            target = hit.collider.gameObject;
           
        }
    }
}
