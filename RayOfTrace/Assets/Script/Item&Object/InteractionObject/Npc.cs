using UnityEngine;

public class Npc : InteractionObject, Interactive
{
    [SerializeField]
    private string name;

    [SerializeField]
    private TextMesh chat;

    [SerializeField]
    private NpcSheet npcSheet;

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

    protected override void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            base.OnTriggerExit2D(col);

            SetupMessageBox(false);
        }
    }

    void SetupMessageBox(bool isSetup)
    {
        if (isSetup)
        {
            chat.gameObject.SetActive(true);

            chat.text = npcSheet.m_data[npcIndex].chat[count];

            if (count < npcSheet.m_data[npcIndex].chat.Count - 1)
                count++;

            else
                count = 0;
        }
        else
        {
            chat.gameObject.SetActive(false);

            count = 0;
        }
    }

    void Interactive.Interaction()
    {
        SetupMessageBox(true);
    }
}