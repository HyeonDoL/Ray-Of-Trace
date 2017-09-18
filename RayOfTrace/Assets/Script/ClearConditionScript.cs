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
    private float m_time;
    private int m_hp;
    private int m_ink;
    private int m_hour;
    private int m_min;
    private int m_sec;

    [SerializeField]
    private DrawLine line;
	void Start () {
        line = this.GetComponent<DrawLine>();
        m_time = 0;
        m_hp = 100;
        m_ink = line.Max;

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
       
    }
}
