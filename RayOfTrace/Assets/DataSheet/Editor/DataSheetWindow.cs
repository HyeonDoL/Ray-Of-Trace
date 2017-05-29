using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;

public class DataSheetWindow : EditorWindow
{
    [SerializeField]
    SheetBase m_target;
        
    Rect SheetDrawPos;

    float SingleLineHeight { get { return EditorGUIUtility.singleLineHeight; } }
    float indexWidth = 30f;
    float fieldWidth = 80f;

    Vector2 scrollVector = Vector2.zero;

    [MenuItem("Window/DataSheetEditor")]
    public static void OpenWindow() {
        var window =  CreateInstance<DataSheetWindow>();
        window.titleContent = new GUIContent("DataSheet");
        window.Show();
    }
        
    public void OnEnable()
    {
        SetupGUIPosition();
    }

    void SetupGUIPosition()
    {
        SheetDrawPos = new Rect(0, SingleLineHeight, fieldWidth, SingleLineHeight);
    }
        

    public void OnGUI()
    {
        ObjectDraw();
            
        if (m_target == null)
            return;

        SheetDraw(); 
    }

    void ObjectDraw()
    {
        m_target = EditorGUI.ObjectField(new Rect(0, 0, position.width * 0.5f, SingleLineHeight), m_target, typeof(SheetBase), false) as SheetBase;

        indexWidth = EditorGUI.FloatField(new Rect(position.width * 0.5f, 0, position.width * 0.1f, SingleLineHeight), indexWidth);
        fieldWidth = EditorGUI.FloatField(new Rect(position.width * 0.6f, 0, position.width * 0.1f, SingleLineHeight), fieldWidth);
    }

    void SheetDraw()
    {
        var pos = SheetDrawPos;
        var fields = m_target.SheetDataType.GetFields();
         
        pos.x += indexWidth;
            
        for (int n = 0; n < fields.Count(); n++)
        {
            EditorGUI.LabelField(pos, fields[n].Name);
            pos.x += fieldWidth;
        }
            
        pos.x = 0;
        pos.y += SingleLineHeight;

        var scrollRect = pos;
        scrollRect.width = position.width;
        scrollRect.height = position.height - SingleLineHeight * 2;

        scrollVector = GUI.BeginScrollView(scrollRect, scrollVector,
            new Rect(
            0,
            SingleLineHeight * 2,
            position.width - indexWidth,
            SingleLineHeight * m_target.Count
            ));

        int viewCount = (int)(scrollRect.height / SingleLineHeight);
        int start = Math.Max(0, (int)(scrollVector.y / SingleLineHeight));
        pos.y += start * SingleLineHeight;

        if (viewCount > m_target.Count)
            scrollVector = Vector2.zero;
            
        for (int i = start; i < start + viewCount && i < m_target.Count ; i++)
        {
            var listItem = m_target.GetListItemObject(i);
            pos.x = 0;
            pos.width = indexWidth;
            EditorGUI.LabelField(pos, i.ToString());
            pos.width = fieldWidth;
            pos.x += indexWidth;

            for (int n = 0; n < fields.Count(); n++)
            {
                switch (fields[n].FieldType.Name)
                {
                    case "Single":
                        FloatField(pos, listItem, fields[n]);  
                        break;
                    case "Int32":
                        IntField(pos, listItem, fields[n]);
                        break;
                    case "String":
                        StringField(pos, listItem, fields[n]);
                        break;
                    case "Color":
                        ColorField(pos, listItem, fields[n]);
                        break;
                    default:
                            
                        if (fields[n].GetValue(listItem) is UnityEngine.Object)
                        {
                            ObjectField(pos, listItem, fields[n]);
                        }

                        break;


                }
                pos.x += fieldWidth;
            }
            pos.y += SingleLineHeight;
        }
        GUI.EndScrollView();
    }

    private void FloatField(Rect position, object value, FieldInfo fieldInfo)
    {
        EditorGUI.BeginChangeCheck();
        var change = EditorGUI.FloatField(position, (float)fieldInfo.GetValue(value));
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(m_target, "Edit Float Field");
            EditorUtility.SetDirty(m_target);
            fieldInfo.SetValue(value, change);
        }
    }
    private void IntField(Rect position, object value, FieldInfo fieldInfo)
    {
        EditorGUI.BeginChangeCheck();
        var change = EditorGUI.IntField(position, (int)fieldInfo.GetValue(value));
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(m_target, "Edit Int Field");
            EditorUtility.SetDirty(m_target);
            fieldInfo.SetValue(value, change);
        }
    }
    private void StringField(Rect position, object value, FieldInfo fieldInfo)
    {
        EditorGUI.BeginChangeCheck();
        var change = EditorGUI.TextField(position, (string)fieldInfo.GetValue(value));
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(m_target, "Edit String Field");
            EditorUtility.SetDirty(m_target);
            fieldInfo.SetValue(value, change);
        }
    }

    private void ColorField(Rect position, object value, FieldInfo fieldInfo)
    {
        EditorGUI.BeginChangeCheck();
        var change = EditorGUI.ColorField(position, (Color)fieldInfo.GetValue(value));
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(m_target, "Edit String Field");
            EditorUtility.SetDirty(m_target);
            fieldInfo.SetValue(value, change);
        }
    }

    private void ObjectField(Rect position, object value, FieldInfo fieldInfo)
    {
        EditorGUI.BeginChangeCheck();
        var change = EditorGUI.ObjectField(position, (UnityEngine.Object)fieldInfo.GetValue(value),fieldInfo.FieldType,false);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(m_target, "Edit String Field");
            EditorUtility.SetDirty(m_target);
            fieldInfo.SetValue(value, change);
        }
    }

}