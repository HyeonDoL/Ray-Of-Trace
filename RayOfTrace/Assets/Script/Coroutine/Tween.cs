using System.Collections;
using UnityEngine;

public static class Tween
{
    private static readonly AnimationCurve defaultCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public static class TweenSprite
    {
        public static IEnumerator TweenColor(SpriteRenderer target, Color end, float time, AnimationCurve curve = null)
        {
            float t = 0f;

            Color start = target.color;

            if (curve == null)
                curve = defaultCurve;

            while (t < 1f)
            {
                t += Time.deltaTime / time;

                target.color = Color.Lerp(start, end, curve.Evaluate(t));

                yield return null;
            }
        }

        public static IEnumerator TweenAlpha(SpriteRenderer target, float alphaEnd, float time, AnimationCurve curve = null)
        {
            float t = 0f;

            Color color = target.color;

            Color start = color;
            Color end = color;

            end.a = alphaEnd;

            if (curve == null)
                curve = defaultCurve;

            while (t < 1f)
            {
                t += Time.deltaTime / time;

                target.color = Color.Lerp(start, end, curve.Evaluate(t));

                yield return null;
            }
        }
    }

    public static class TweenMaterial
    {
        public static IEnumerator TweenColor(Material target, Color end, float time, AnimationCurve curve = null)
        {
            float t = 0f;

            Color start = target.color;

            if (curve == null)
                curve = defaultCurve;

            while (t < 1f)
            {
                t += Time.deltaTime / time;

                target.color = Color.Lerp(start, end, curve.Evaluate(t));

                yield return null;
            }
        }

        public static IEnumerator TweenAlpha(Material target, float alphaEnd, float time, AnimationCurve curve = null)
        {
            float t = 0f;

            Color color = target.color;

            Color start = color;
            Color end = color;

            end.a = alphaEnd;

            if (curve == null)
                curve = defaultCurve;

            while (t < 1f)
            {
                t += Time.deltaTime / time;

                target.color = Color.Lerp(start, end, curve.Evaluate(t));

                yield return null;
            }
        }
    }

    public static class TweenTransform
    {
        public static IEnumerator TweenTrans(Transform target, Vector3 positionEnd, Quaternion rotationEnd, Vector3 scaleEnd, float time, AnimationCurve curve = null)
        {
            float t = 0f;

            Vector3 startPos = target.position;
            Quaternion startRot = target.rotation;
            Vector3 startScale = target.localScale;

            if (curve == null)
                curve = defaultCurve;

            while (t < 1f)
            {
                t += Time.deltaTime / time;

                target.position = Vector3.Lerp(startPos, positionEnd, curve.Evaluate(t));

                target.rotation = Quaternion.Lerp(startRot, rotationEnd, curve.Evaluate(t));

                target.localScale = Vector3.Lerp(startScale, scaleEnd, curve.Evaluate(t));

                yield return null;
            }
        }
        public static IEnumerator TweenTrans(Transform target, Transform end, float time, AnimationCurve curve = null)
        {
            float t = 0f;

            Vector3 startPos = target.position;
            Quaternion startRot = target.rotation;
            Vector3 startScale = target.localScale;

            if (curve == null)
                curve = defaultCurve;

            while(t < 1f)
            {
                t += Time.deltaTime / time;

                target.position = Vector3.Lerp(startPos, end.position, curve.Evaluate(t));

                target.rotation = Quaternion.Lerp(startRot, end.rotation, curve.Evaluate(t));

                target.localScale = Vector3.Lerp(startScale, end.localScale, curve.Evaluate(t));

                yield return null;
            }
        }

        public static IEnumerator Position(Transform target, Vector3 end, float time, AnimationCurve curve = null)
        {
            float t = 0f;

            Vector3 start = target.position;

            if (curve == null)
                curve = defaultCurve;

            while (t < 1f)
            {
                t += Time.deltaTime / time;

                target.position = Vector3.Lerp(start, end, curve.Evaluate(t));

                yield return null;
            }
        }

        public static IEnumerator Rotation(Transform target, Quaternion end, float time, AnimationCurve curve = null)
        {
            float t = 0f;

            Quaternion start = target.rotation;

            if (curve == null)
                curve = defaultCurve;

            while (t < 1f)
            {
                t += Time.deltaTime / time;

                target.rotation = Quaternion.Lerp(start, end, curve.Evaluate(t));

                yield return null;
            }
        }

        public static IEnumerator LocalScale(Transform target, Vector3 end, float time, AnimationCurve curve = null)
        {
            float t = 0f;

            Vector3 start = target.localScale;

            if (curve == null)
                curve = defaultCurve;

            while(t < 1f)
            {
                t += Time.deltaTime / time;

                target.localScale = Vector3.Lerp(start, end, curve.Evaluate(t));

                yield return null;
            }
        }
    }
}