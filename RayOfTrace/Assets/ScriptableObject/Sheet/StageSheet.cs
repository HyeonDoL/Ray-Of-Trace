using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class StageData
{
    public int stageLv;

    public List<Achievement> stageAchievementList = new List<Achievement>();
}

public class StageSheet : Sheet<StageData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/StageSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<StageSheet>();
    }
#endif
}