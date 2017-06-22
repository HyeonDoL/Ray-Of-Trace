using UnityEngine;

public class ShadowBlock : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D collider;

    [SerializeField]
    private SpriteRenderer spriteRender;

    [SerializeField]
    private float changeTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Firefly"))
        {
            StartCoroutine(Tween.TweenSprite.TweenAlpha(spriteRender, 0f, changeTime));

            collider.isTrigger = true;
        }
    }
}