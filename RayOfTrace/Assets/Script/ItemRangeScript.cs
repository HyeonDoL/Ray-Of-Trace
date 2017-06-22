using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRangeScript : MonoBehaviour {

    private GameObject target;
    private RaycastHit2D hit;
    private Vector3 postion;
    public bool ison = false;
    public void CastRay()
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
            postion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ison = true;
        }
    }
    public Vector3 ItemPosition()
    {
        return postion;
    }
}
