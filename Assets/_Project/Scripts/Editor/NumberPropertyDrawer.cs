using CI.Utilities;
using UnityEditor;
using UnityEngine;

namespace Terra.Editor
{
    [CustomPropertyDrawer(typeof(Number))]
    public class NumberPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (position.width == 1f)
            {
                position.width = EditorGUIUtility.currentViewWidth;
            }

            EditorGUI.BeginProperty(position, label, property);

            var rectBuilder = new HorizontalRectBuilder(position);
            rectBuilder.AddPadding(18f);

            var additionalIndent = 18f + (9f * EditorGUI.indentLevel);

            var labelWidth = EditorGUIUtility.labelWidth;
            if (EditorGUI.indentLevel != 0)
            {
                labelWidth -= additionalIndent;
            }

            var fieldWidth = position.width - labelWidth - 10f;
			
            var labelRect = rectBuilder.Add(labelWidth);
            var valueRect = rectBuilder.Add(fieldWidth * 0.7f);
            var exponentLabelRect = rectBuilder.Add(10f);
            var exponentRect = rectBuilder.Add(fieldWidth * 0.3f);

            EditorGUI.PrefixLabel(labelRect, label);
            EditorGUI.PropertyField(valueRect, property.FindPropertyRelative(nameof(Number.Mantissa)), GUIContent.none);
            EditorGUI.PrefixLabel(exponentLabelRect, new GUIContent("E"));
            EditorGUI.PropertyField(exponentRect, property.FindPropertyRelative(nameof(Number.Exponent)), GUIContent.none);

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}