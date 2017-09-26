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
    private int[] acheivearr = new int[10]; 
    void Start()
    {
       // PlayerPrefs.SetInt(Prefstype.C1_1, 0);
        chat[0].color = Color.gray;
        chat[1].color = Color.gray;
        chat[2].color = Color.gray;
        acheivearr[0] = PlayerPrefs.GetInt(Prefstype.C1_1);
        acheivearr[1] = PlayerPrefs.GetInt(Prefstype.C1_2);
        acheivearr[2] = PlayerPrefs.GetInt(Prefstype.C1_3);
        acheivearr[3] = PlayerPrefs.GetInt(Prefstype.C2_1);
        acheivearr[4] = PlayerPrefs.GetInt(Prefstype.C2_2);
        acheivearr[5] = PlayerPrefs.GetInt(Prefstype.C2_3);
        acheivearr[6] = PlayerPrefs.GetInt(Prefstype.C3_1);
        acheivearr[7] = PlayerPrefs.GetInt(Prefstype.C3_2);
        acheivearr[8] = PlayerPrefs.GetInt(Prefstype.C3_3);
      
    }
    private void Update()
    {
        StageLv = chaptermanager.pages - 1;
        if (chaptermanager.pages == 1)
        {
            if (acheivearr[0] == 1)
                chat[0].color = Color.white;
            else
                chat[0].color = Color.gray;

            if (acheivearr[1] == 1)
                chat[1].color = Color.white;
            else
                chat[1].color = Color.gray;

            if (acheivearr[2] == 1)
                chat[2].color = Color.white;
            else
                chat[2].color = Color.gray;
        }
        else if (chaptermanager.pages == 2)
        {
            if (acheivearr[3] == 1)
                chat[0].color = Color.white;
            else
                chat[0].color = Color.gray;
            if (acheivearr[4] == 1)
                chat[1].color = Color.white;
            else
                chat[1].color = Color.gray;
            if (acheivearr[5] == 1)
                chat[2].color = Color.white;
            else
                chat[2].color = Color.gray;
        }
        else if (chaptermanager.pages == 3)
        {
            if (acheivearr[6] == 1)
                chat[0].color = Color.white;
            else
                chat[0].color = Color.gray;
            if (acheivearr[7] == 1)
                chat[1].color = Color.white;
            else
                chat[1].color = Color.gray;
            if (acheivearr[8] == 1)
                chat[2].color = Color.white;
            else
                chat[2  ].color = Color.gray;
        }
        chat[0].text = stageSheet.m_data[StageLv].achievementTextList[0].name + ": \n" + stageSheet.m_data[StageLv].achievementTextList[0].content;
        chat[1].text = stageSheet.m_data[StageLv].achievementTextList[1].name + ": \n" + stageSheet.m_data[StageLv].achievementTextList[1].content;
        chat[2].text = stageSheet.m_data[StageLv].achievementTextList[2].name + ": \n" + stageSheet.m_data[StageLv].achievementTextList[2].content;
    }
    public void setText()
    {
        chat[0].text = stageSheet.m_data[StageLv].achievementTextList[0].content;
        chat[1].text = stageSheet.m_data[StageLv].achievementTextList[1].content;
        chat[2].text = stageSheet.m_data[StageLv].achievementTextList[2].content;
    }
   
    
}
