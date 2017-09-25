using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementWindow : MonoBehaviour {

    [SerializeField]
    private int StageLv;

    [SerializeField]
    private Text[] chat;

    [SerializeField]
    private AchievementTextSheet stageSheet;
    [SerializeField]
    private ChapterManager chaptermanager;
    private int npcIndex;

    private int count;

    void Start()
    {
        chat[0].color = Color.gray;
        chat[1].color = Color.gray;
        chat[2].color = Color.gray;
    }
    private void Update()
    {
        StageLv = chaptermanager.pages - 1;
        if (chaptermanager.pages == 1)
        {
            if (PlayerPrefs.GetInt(Prefstype.C1_1) == 1)
                chat[0].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C1_2) == 1)
                chat[1].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C1_3) == 1)
                chat[2].color = Color.white;
        }
        else if (chaptermanager.pages == 2)
        {
            if (PlayerPrefs.GetInt(Prefstype.C2_1) == 1)
                chat[0].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C2_2) == 1)
                chat[1].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C2_3) == 1)
                chat[2].color = Color.white;
        }
        else if (chaptermanager.pages == 3)
        {
            if (PlayerPrefs.GetInt(Prefstype.C3_1) == 1)
                chat[0].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C3_2) == 1)
                chat[1].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C3_3) == 1)
                chat[2].color = Color.white;
        }
        chat[0].text = stageSheet.m_data[StageLv].achievementTextList[0].content;
        chat[1].text = stageSheet.m_data[StageLv].achievementTextList[1].content;
        chat[2].text = stageSheet.m_data[StageLv].achievementTextList[2].content;
    }
    public void setText()
    {
        chat[0].text = stageSheet.m_data[StageLv].achievementTextList[0].content;
        chat[1].text = stageSheet.m_data[StageLv].achievementTextList[1].content;
        chat[2].text = stageSheet.m_data[StageLv].achievementTextList[2].content;
    }
   
    
}
