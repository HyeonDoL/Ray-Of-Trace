using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class NpcData
{
    public string name;

    [TextArea]
    public List<string> chat;
}

public class NpcSheet : Sheet<NpcData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/NpcSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<NpcSheet>();
    }
#endif
}