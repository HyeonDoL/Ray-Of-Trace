using UnityEngine;

public class Crystal : MonoBehaviour, InteractionObject
{
    [SerializeField]
    private Crystal component;

    private PlayerInteraction playerInteraction;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IngameButtonManager.Instance.IsAction = true;

            playerInteraction = col.gameObject.GetComponent<PlayerInteraction>();

            playerInteraction._InteractionObject = component;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerInteraction._InteractionObject == null)
            {
                playerInteraction = other.gameObject.GetComponent<PlayerInteraction>();

                playerInteraction._InteractionObject = component;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IngameButtonManager.Instance.IsAction = false;

            playerInteraction._InteractionObject = null;
        }
    }

    void InteractionObject.Interaction()
    {
        Destroy(this.gameObject);

    }
}