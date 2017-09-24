using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClearConditionScript : MonoBehaviour {

    [SerializeField]
    private Text time;
    [SerializeField]
    private Text cleartime;
    [SerializeField]
    private Text clearText;
    [SerializeField]
    private Text[] chat;
    [SerializeField]
    private Image HpGuage;
  
    [SerializeField]
    private Image InkGuage;
    [SerializeField]
    private Slider mapslider;
    [SerializeField]
    private AchievementTextSheet stageSheet;
    public int[] crashnum;
    private int m_havecrashnum;
    private int m_hp;
    private int m_ink;
    private int m_min;
    private int m_sec;
    private int m_chapternum;
    private int m_hit;
    private int m_hitCount;
    [SerializeField]
    private int m_achievenum;
    private float m_time;

    [SerializeField]
    private DrawLine line;
    [SerializeField]
    private IngameButtonManager button;
    [SerializeField]
    private Camera mapcamera;
	void Start () {
        //PlayerPrefs.SetInt(Prefstype.C1_1, 0);
        //PlayerPrefs.SetInt(Prefstype.C1_2, 0);
        //PlayerPrefs.SetInt(Prefstype.C1_3, 0);
        //PlayerPrefs.SetInt(Prefstype.C2Unlock, 0);
        line = this.GetComponent<DrawLine>();
        m_time = 0;
        m_hp = -100;
        m_achievenum = 0;
        m_ink = line.Max;
        m_hitCount = 0;
        m_chapternum = PlayerPrefs.GetInt(Prefstype.ChapterNum);
        chat[0].color = Color.gray;
        chat[1].color = Color.gray;
        chat[2].color = Color.gray;
        PlayerPrefs.SetInt(Prefstype.PlayerHit,0);
        if(m_chapternum == 1)
        {
            if(PlayerPrefs.GetInt(Prefstype.C1_1) == 1)
                chat[0].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C1_2) == 1)
                chat[1].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C1_3) == 1)
                chat[2].color = Color.white;
        }
        else if (m_chapternum == 2)
        {
            if (PlayerPrefs.GetInt(Prefstype.C2_1) == 1)
                chat[0].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C2_2) == 1)
                chat[1].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C2_3) == 1)
                chat[2].color = Color.white;
        }
        else if(m_chapternum == 3)
        {
            if (PlayerPrefs.GetInt(Prefstype.C3_1) == 1)
                chat[0].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C3_2) == 1)
                chat[1].color = Color.white;
            if (PlayerPrefs.GetInt(Prefstype.C3_3) == 1)
                chat[2].color = Color.white;
        }

    }

	void Update () {
        m_hit = PlayerPrefs.GetInt(Prefstype.PlayerHit);
        m_ink = line.Max - line.n;
        m_time += Time.deltaTime;
        m_min = ((int)m_time / 60)%60;
        m_sec = (int)m_time % 60;
        if (m_sec < 10)
            time.text = "" + m_min + " : " + 0 + m_sec;
        else
            time.text = "" + m_min + " : " + m_sec;

        InkGuage.fillAmount = m_ink * 0.01f;
        HpGuage.fillAmount = m_hp * 0.01f;
        mapcamera.orthographicSize = 6f + (mapslider.value * 10f);
        if(m_hit == 1)
        {
            //TODO : 쳐맞은거 여기서 하면 될듯
            m_hitCount++;
            PlayerPrefs.SetInt(Prefstype.PlayerHit,0);
        }
        if(m_hp <0)
        {
            clearText.text = "Fail...";
            this.GetComponent<IngameButtonManager>().ClearWindow();
           
            if (m_sec < 10)
                cleartime.text = "" + m_min + " : " + 0 + m_sec;
            else
                cleartime.text = "" + m_min + " : " + m_sec;
            chat[0].text = stageSheet.m_data[m_chapternum - 1].achievementTextList[0].content;
            chat[1].text = stageSheet.m_data[m_chapternum - 1].achievementTextList[1].content;
            chat[2].text = stageSheet.m_data[m_chapternum - 1].achievementTextList[2].content;
            this.enabled = false;
        }
        else if (crashnum[m_chapternum] == m_havecrashnum)
        {
            clearText.text = "Clear!";
            this.GetComponent<IngameButtonManager>().ClearWindow();
            Cleared(); 
            if (m_sec < 10)
                cleartime.text = "" + m_min + " : " + 0 + m_sec;
            else
                cleartime.text = "" + m_min + " : " + m_sec;
            chat[0].text = stageSheet.m_data[m_chapternum - 1].achievementTextList[0].content;
            chat[1].text = stageSheet.m_data[m_chapternum - 1].achievementTextList[1].content;
            chat[2].text = stageSheet.m_data[m_chapternum - 1].achievementTextList[2].content;
            this.enabled = false;
        }
        
    
       
    }
    private void Cleared()
    {

        if (m_chapternum == 1)
        {
            m_achievenum = PlayerPrefs.GetInt(Prefstype.C1_1, 0) +
               PlayerPrefs.GetInt(Prefstype.C1_2, 0) +
               PlayerPrefs.GetInt(Prefstype.C1_3, 0);
            if (m_hitCount == 0)
            {
                PlayerPrefs.SetInt(Prefstype.C1_1, 1);
                chat[0].color = Color.white;
              
            }
            if (button.Itemusenum < 10)
            {
                PlayerPrefs.SetInt(Prefstype.C1_2, 1);
                chat[1].color = Color.white;
         
            }
            if (m_time <= 180)
            {
                PlayerPrefs.SetInt(Prefstype.C1_3, 1);
                chat[2].color = Color.white;
            

            }
            if (m_achievenum == 3)
            {
                PlayerPrefs.SetInt(Prefstype.C2Unlock, 1);
            }
        }
        else if (m_chapternum == 2)
        {
            m_achievenum = PlayerPrefs.GetInt(Prefstype.C2_1, 0) +
               PlayerPrefs.GetInt(Prefstype.C2_2, 0) +
               PlayerPrefs.GetInt(Prefstype.C2_3, 0);
            if (m_hit == 0)
            {
                PlayerPrefs.SetInt(Prefstype.C2_1, 1);
                chat[0].color = Color.white;
           
            }
            if (button.Itemusenum < 10)
            {
                PlayerPrefs.SetInt(Prefstype.C2_2, 1);
                chat[1].color = Color.white;
             
            }
            if (m_time <= 180)
            {
                PlayerPrefs.SetInt(Prefstype.C2_3, 1);
                chat[2].color = Color.white;

            }
            if (m_achievenum == 3)
            {
                PlayerPrefs.SetInt(Prefstype.C3Unlock, 1);
            }
        }
        else if (m_chapternum == 3)
        {
            m_achievenum = PlayerPrefs.GetInt(Prefstype.C3_1, 0) +
               PlayerPrefs.GetInt(Prefstype.C3_2, 0) +
               PlayerPrefs.GetInt(Prefstype.C3_3, 0);
            if (m_hit == 0)
            {
                PlayerPrefs.SetInt(Prefstype.C3_1, 1);
                chat[0].color = Color.white;
               
            }
            if (button.Itemusenum < 10)
            {
                PlayerPrefs.SetInt(Prefstype.C3_2, 1);
                chat[1].color = Color.white;
               
            }
            if (m_time <= 180)
            {
                PlayerPrefs.SetInt(Prefstype.C3_3, 1);
                chat[2].color = Color.white;
              
            }
            if (m_achievenum == 3)
            {
                PlayerPrefs.SetInt(Prefstype.C4Unlock, 1);
            }
        }
       
    }
}
