using UnityEngine;

public class Npc : MonoBehaviour, InteractionObject
{
    [SerializeField]
    private string name;

    [SerializeField]
    private TextMesh chat;

    [SerializeField]
    private NpcSheet npcSheet;

    [SerializeField]
    private Npc npcComponent;

    private PlayerInteraction playerInteraction;

    private int npcIndex;

    private int count;

    void Awake()
    {
        count = 0;

        for (npcIndex = 0; npcIndex < npcSheet.m_data.Count; npcIndex++)
        {
            if (npcSheet.m_data[npcIndex].name == this.name)
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IngameButtonManager.Instance.IsAction = true;

            playerInteraction = col.gameObject.GetComponent<PlayerInteraction>();

            playerInteraction._InteractionObject = npcComponent;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerInteraction._InteractionObject == null)
            {
                playerInteraction = other.gameObject.GetComponent<PlayerInteraction>();

                playerInteraction._InteractionObject = npcComponent;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IngameButtonManager.Instance.IsAction = false;

            playerInteraction._InteractionObject = null;

            SetupMessageBox(false);
        }
    }

    void SetupMessageBox(bool isSetup)
    {
        if (isSetup)
        {
            chat.text = npcSheet.m_data[npcIndex].chat[count];

            if (count < npcSheet.m_data[npcIndex].chat.Count - 1)
                count++;
        }
        else
        {
            count = 0;
        }
    }

    void InteractionObject.Interaction()
    {
        SetupMessageBox(true);
    }
}