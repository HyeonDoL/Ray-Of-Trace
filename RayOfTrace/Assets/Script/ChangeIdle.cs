using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIdle : MonoBehaviour {

    [SerializeField]
    private IngameButtonManager m_ingameButtonManager;
	
    public void ClearAnimation()
    {
        m_ingameButtonManager.ClearAnimation();
    }
}
