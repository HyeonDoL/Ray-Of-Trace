using UnityEngine;
using System.Collections;

public class SpawnTutorialNpc : MonoBehaviour
{
    [SerializeField]
    private TutorialNpc tutorialNpc;

    [SerializeField]
    private float spawnTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            tutorialNpc.transform.position = this.transform.position;

            tutorialNpc.SetupMessageBox(false);

            tutorialNpc.AddTypeCount();

            SpriteRenderer tutorialNpcRender = tutorialNpc.GetSpriteRenderer();

            tutorialNpcRender.color = new Color(1f, 1f, 1f, 0f);

            StartCoroutine(Tween.TweenSprite.TweenAlpha(tutorialNpcRender, 1f, spawnTime));

            Destroy(this.gameObject, spawnTime + 0.1f);
        }
    }
}