using UnityEngine;

public class LightBlock : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D collider;

    [SerializeField]
    private SpriteRenderer spriteRender;

    [SerializeField]
    private float changeTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ink"))
        {
            StartCoroutine(Tween.TweenSprite.TweenColor(spriteRender, Color.black, changeTime));

            collider.isTrigger = false;
        }
    }
}