using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
using System;
#endif

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ActionData))]
public class ActionDataDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

		EditorGUI.BeginProperty(position, label, property);

		EditorGUILayout.BeginVertical();

		var type = property.FindPropertyRelative("type");
		type.enumValueIndex = Convert.ToInt32(EditorGUILayout.EnumPopup("Action Type", (ActionData.Type)Enum.ToObject(typeof(ActionData.Type), type.enumValueIndex)));

		EditorGUILayout.Space();

		var waitTime = property.FindPropertyRelative("waitTime");
		if (type.enumValueIndex != 0) {
			GUI.enabled = false;
		}
		waitTime.floatValue = EditorGUILayout.FloatField("Wait Time", waitTime.floatValue);
		GUI.enabled = true;

		var pos = property.FindPropertyRelative("position");
		if (type.enumValueIndex != 1 && type.enumValueIndex != 2 && type.enumValueIndex != 5) {
			GUI.enabled = false;
		}
		pos.vector3Value = EditorGUILayout.Vector3Field("Position", pos.vector3Value);
		GUI.enabled = true;

		var speed = property.FindPropertyRelative("speed");
		if (type.enumValueIndex != 1 && type.enumValueIndex != 2 && type.enumValueIndex != 3 && type.enumValueIndex != 4 && type.enumValueIndex != 8 && type.enumValueIndex != 9) {
			GUI.enabled = false;
		}
		speed.floatValue = EditorGUILayout.FloatField("Speed", speed.floatValue);
		GUI.enabled = true;

		var bullets = property.FindPropertyRelative("bullets");
		if (type.enumValueIndex != 3 && type.enumValueIndex != 4 && type.enumValueIndex != 8 && type.enumValueIndex != 9) {
			GUI.enabled = false;
		}
		bullets.intValue = EditorGUILayout.IntField("Bullets", bullets.intValue);
		GUI.enabled = true;

		var tbs = property.FindPropertyRelative("timeBetweenShots");
		if (type.enumValueIndex != 3 && type.enumValueIndex != 4 && type.enumValueIndex != 9) {
			GUI.enabled = false;
		}
		tbs.floatValue = EditorGUILayout.FloatField("Time Between Shots", tbs.floatValue);
		GUI.enabled = true;

		var target = property.FindPropertyRelative("target");
		if (type.enumValueIndex != 6) {
			GUI.enabled = false;
		}
		target.objectReferenceValue = EditorGUILayout.ObjectField("Target", target.objectReferenceValue, typeof(Transform), true);
		GUI.enabled = true;

		var loops = property.FindPropertyRelative("numberOfLoops");
		if (type.enumValueIndex != 10 && type.enumValueIndex != 11) {
			GUI.enabled = false;
		}
		loops.intValue = EditorGUILayout.IntField("Number of Loops", loops.intValue);
		GUI.enabled = true;

		var angle = property.FindPropertyRelative("angle");
		if (type.enumValueIndex != 13) {
			GUI.enabled = false;
		}
		angle.floatValue = EditorGUILayout.FloatField("Angle", angle.floatValue);
		GUI.enabled = true;

		EditorGUILayout.Space();
		EditorGUILayout.Space();

		EditorGUILayout.EndVertical();

		EditorGUI.EndProperty();

	}

}
#endif
