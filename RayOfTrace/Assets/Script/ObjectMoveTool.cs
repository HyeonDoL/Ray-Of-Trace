using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveTool : MonoBehaviour
{
    [System.Serializable]
    private struct LinePoint
    {
        public Transform trans;
        public float time;
        public AnimationCurve curve;
    }

    [SerializeField]
    private Transform target;

    [SerializeField]
    private List<LinePoint> path = new List<LinePoint>();

    [SerializeField]
    private bool playerOnAwake;

    [SerializeField]
    private bool loop;

    private readonly AnimationCurve defaultCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private void Awake()
    {
        if (playerOnAwake)
            StartCoroutine(StartMove());
    }

    private void OnDrawGizmosSelected()
    {
        for(int count = 0; count < path.Count - 1; count++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(path[count].trans.position, Vector3.one);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(path[count].trans.position, path[count + 1].trans.position);
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(path[path.Count - 1].trans.position, Vector3.one);

        if(loop)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(path[path.Count - 1].trans.position, path[0].trans.position);
        }
    }

    public IEnumerator StartMove()
    {
        do
        {
            for (int count = 0; count < path.Count; count++)
            {
                LinePoint point = path[count];

                Vector3 start = this.transform.position;
                Vector3 end = point.trans.position;

                float t = 0f;

                if (point.curve.length == 0)
                    point.curve = defaultCurve;

                while (t < 1f)
                {
                    t += Time.deltaTime / point.time;

                    target.transform.position = Vector3.Lerp(start, end, point.curve.Evaluate(t));

                    yield return null;
                }
            }
        } while (loop);
    }
}