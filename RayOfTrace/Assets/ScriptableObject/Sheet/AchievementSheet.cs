using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class AchievementData
{
    public string name;

    [TextArea]
    public string contents;

    
}

public class AchievementSheet : Sheet<AchievementData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/AchievementSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<AchievementSheet>();
    }
#endif
}