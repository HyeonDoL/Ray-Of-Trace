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

    void Awake()
    {
      
    }
    private void Update()
    {
        StageLv = chaptermanager.pages - 1;
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
