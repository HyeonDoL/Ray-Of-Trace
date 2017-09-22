using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public struct AchievementText
{
    public string name;

    [TextArea]
    public string content;
}

[System.Serializable]
public class AchievementTextData
{
    public List<AchievementText> achievementTextList;
}

public class AchievementTextSheet : Sheet<AchievementTextData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/AchievementTextSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<AchievementTextSheet>();
    }
#endif
}