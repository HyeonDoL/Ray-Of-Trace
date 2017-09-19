using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClearConditionScript : MonoBehaviour {

    [SerializeField]
    private Text time;
    [SerializeField]
    private Image HpGuage;
    [SerializeField]
    private Image InkGuage;
    [SerializeField]
    private Slider mapslider;
    private float m_time;
    private int m_hp;
    private int m_ink;
    private int m_hour;
    private int m_min;
    private int m_sec;
    private int m_chapternum;
    [SerializeField]
    private DrawLine line;
    [SerializeField]
    private IngameButtonManager button;
    [SerializeField]
    private Camera mapcamera;
	void Start () {
        line = this.GetComponent<DrawLine>();
        m_time = 0;
        m_hp = 100;
        m_ink = line.Max;
        m_chapternum = PlayerPrefs.GetInt(Prefstype.ChapterNum);
       
    }

	void Update () {
        m_ink = line.Max - line.n;
        m_time += Time.deltaTime;
        m_hour = (int)m_time / 3600;
        m_min = ((int)m_time / 60)%60;
        m_sec = (int)m_time % 60;
        if (m_sec < 10)
            time.text = "" + m_hour + m_min + " : " + 0 + m_sec;
        else
            time.text = "" + m_hour + m_min + " : " + m_sec;

        InkGuage.fillAmount = m_ink * 0.01f;
        HpGuage.fillAmount = m_hp * 0.01f;
        mapcamera.orthographicSize = 6f + (mapslider.value * 10f);
       
        if(m_chapternum == 1)
        {
            //if (hit  == 0)
            //   PlayerPrefs.SetInt(Prefstype.C1_1, 1);
            if(button.Itemusenum < 10)
                PlayerPrefs.SetInt(Prefstype.C1_2,1);
            if(m_time<=180)
                PlayerPrefs.SetInt(Prefstype.C1_3,1);
        }
    }
}
