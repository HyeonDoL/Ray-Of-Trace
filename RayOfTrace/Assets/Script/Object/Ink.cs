using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink : MonoBehaviour
{
    [SerializeField]
    private Transform handTrans;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            return;

        Destroy(this.gameObject);
    }
}