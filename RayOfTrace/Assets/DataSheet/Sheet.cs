using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System.ComponentModel;

#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class SheetBase : ScriptableObject
{

    private IList List
    {
        get
        {
            return (IList)GetType().GetField("m_data", BindingFlags.Public | BindingFlags.Instance).GetValue(this);
        }
    }

    public Type SheetDataType
    {
        get
        {
            return GetType().GetMember("m_data")[0].DeclaringType.GetGenericArguments()[0];
        }
    }

    public IEnumerable<FieldInfo> memberInfos
    {
        get
        {
            return SheetDataType.GetFields(BindingFlags.Public|BindingFlags.Instance);
        }
    }

    public int Count
    {
        get
        {
            return (int)List.GetType().GetProperty("Count", BindingFlags.Public | BindingFlags.Instance).GetValue(List, null);
        }
    }

    public object GetListItemObject(int index)
    {
        return List[index];
    }
}
    
[Serializable]
public class Sheet<T> : SheetBase
{
    public List<T> m_data = new List<T>();
}