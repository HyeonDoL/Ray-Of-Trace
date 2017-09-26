using UnityEngine;

public class Minimap : InteractionObject, Interactive
{
    [SerializeField]
    private GameObject minimap;

    protected override void OnTriggerExit2D(Collider2D col)
    {
        base.OnTriggerExit2D(col);

        minimap.SetActive(false);
    }

    void Interactive.Interaction()
    {
        minimap.SetActive(true);
    }
}