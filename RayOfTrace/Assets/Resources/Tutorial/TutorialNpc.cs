using System.Collections;
using UnityEngine;

public class TutorialNpc : InteractionObject, Interactive
{
    [SerializeField]
    private TextMesh chat;

    [SerializeField]
    private NpcSheet npcSheet;

    [SerializeField]
    private SpriteRenderer spriteRender;

    private int npcIndex;

    private int count;
    private int typeCount;

    private string name;

    void Awake()
    {
        name = "TutorialNPC";

        count = 0;
        typeCount = 0;

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

    public void SetupMessageBox(bool isSetup)
    {
        if (isSetup)
        {
            chat.gameObject.SetActive(true);

            chat.text = npcSheet.m_data[npcIndex + typeCount].chat[count];

            if (count < npcSheet.m_data[npcIndex + typeCount].chat.Count - 1)
                count++;
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

    public void AddTypeCount()
    {
        typeCount += 1;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRender;
    }
}
