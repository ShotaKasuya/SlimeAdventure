using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// 定数をEnumのようにエディタ上で表示する
/// https://qiita.com/msm2001/items/83f628102f021b9559d5
/// </summary>

[AttributeUsage(AttributeTargets.Field)]
public class DropdownConstantsAttribute : PropertyAttribute
{
    private readonly string[] menuNames;
    private readonly string[] menuValues;

    public DropdownConstantsAttribute(Type constantsClass,
        BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
    {
        var fields = constantsClass.GetFields(bindingFlags);
        var menuDictionary = new Dictionary<string, string>(fields.Length);
        foreach (var field in fields)
        {
            if (field.FieldType == typeof(string))
            {
                menuDictionary.Add(field.Name, field.GetValue(constantsClass) as string);
            }
        }

        menuNames = menuDictionary.Keys.ToArray();
        menuValues = menuDictionary.Values.ToArray();
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(DropdownConstantsAttribute))]
    public class DropdownConstantsAttributeDrawer : PropertyDrawer
    {
        // 現在選択されている定数のインデックス
        private int index = -1;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.type != "string") return;

            var targetAttribute = (DropdownConstantsAttribute)attribute;

            if (index < 0)
            {
                index = string.IsNullOrEmpty(property.stringValue)
                    ? 0
                    : Array.IndexOf(targetAttribute.menuValues, property.stringValue);
            }

            // ドロップダウンメニューを表示
            index = EditorGUI.Popup(position, label.text, index, targetAttribute.menuNames);
            property.stringValue = targetAttribute.menuValues[index];
        }
    }
#endif
}
