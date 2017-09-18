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
    private Slider InkGuage;
    private float m_time;
    private int m_hp;
    private int m_ink;
    private int m_hour;
    private int m_min;
    private int m_sec;

	void Start () {
        m_time = 0;
        m_hp = 100;
        m_ink = this.GetComponent<DrawLine>().Max;
	}

	void Update () {
        m_time += Time.deltaTime;
        m_hour = (int)m_time / 3600;
        m_min = ((int)m_time / 60)%60;
        m_sec = (int)m_time % 60;
        if (m_sec < 10)
            time.text = "" + m_hour + m_min + " : " + 0 + m_sec;
        else
            time.text = "" + m_hour + m_min + " : " + m_sec;

       
    }
}
