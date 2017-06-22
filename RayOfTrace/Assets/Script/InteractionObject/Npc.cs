using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TextBox
{
    public TextMesh textMesh;
    public Light light;
}

public class Npc : MonoBehaviour, InteractionObject
{
    [SerializeField]
    private string name;

    [SerializeField]
    private TextBox chatBox;

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

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            playerInteraction = col.gameObject.GetComponent<PlayerInteraction>();

            playerInteraction._InteractionObject = npcComponent;
        }
    }

    private void OnTriggerStay(Collider other)
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

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            playerInteraction._InteractionObject = null;

            SetupMessageBox(false);
        }
    }

    void SetupMessageBox(bool isSetup)
    {
        if (isSetup)
        {
            chatBox.light.enabled = true;

            chatBox.textMesh.text = npcSheet.m_data[npcIndex].chat[count];

            if (count < npcSheet.m_data[npcIndex].chat.Count - 1)
                count++;
        }
        else
        {
            chatBox.light.enabled = false;

            count = 0;
        }
    }

    void InteractionObject.Interaction()
    {
        SetupMessageBox(true);
    }
}