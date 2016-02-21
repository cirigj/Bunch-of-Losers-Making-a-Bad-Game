using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class EditorSaves {
	public static Tool prevTool;
	public static bool customToolUp;
}

[CustomEditor(typeof(BulletShooter))]
public class BulletShooterEditor : Editor {

	BulletShooter targetShooter;
	Vector3 normal;
	Vector3 direction;
	Vector3 directionOrthag;

	void OnSceneGUI () {
		
		targetShooter = (BulletShooter)target;

		if (targetShooter.direction.z != 0f) {
			targetShooter.direction = new Vector3(targetShooter.direction.x, targetShooter.direction.y, 0f);
		}
		if (targetShooter.direction == Vector3.zero) {
			targetShooter.direction = -Vector3.right;
		}
		targetShooter.direction.Normalize();

		normal = targetShooter.transform.forward;
		direction = targetShooter.transform.rotation * targetShooter.direction;
		directionOrthag = Quaternion.AngleAxis(-90f, normal) * direction;
		if (Event.current.type == EventType.keyDown && Event.current.keyCode == KeyCode.Alpha3) {
			if (Tools.current != Tool.None) {
				EditorSaves.prevTool = Tools.current;
				Tools.current = Tool.None;
				EditorSaves.customToolUp = true;
			}
		}
		if (Event.current.type == EventType.keyDown && Event.current.keyCode == KeyCode.Alpha1) {
			if (Tools.current == Tool.None) {
				Tools.current = EditorSaves.prevTool;
				EditorSaves.customToolUp = false;
			}
		}
		if (EditorSaves.customToolUp) {
			Handles.color = Color.white;
			Quaternion newRotation = Handles.RotationHandle(Quaternion.LookRotation(direction, normal), targetShooter.transform.position);
			Handles.color = JBirdEngine.ColorLibrary.MoreColors.purple;
			targetShooter.spreadAngle = Handles.ScaleValueHandle(targetShooter.spreadAngle,
				targetShooter.transform.position + direction * HandleUtility.GetHandleSize(targetShooter.transform.position) * 1.5f,
				Quaternion.LookRotation(direction, normal),
				HandleUtility.GetHandleSize(targetShooter.transform.position) * 1.5f,
				Handles.ConeCap,
				1.0f);
			Handles.color = new Color(1f, 1f, 1f, .25f);
			Handles.DrawSolidArc(targetShooter.transform.position, 
				normal,
				direction * Mathf.Cos(Mathf.Deg2Rad * targetShooter.spreadAngle / 2f) + directionOrthag * Mathf.Sin(Mathf.Deg2Rad * targetShooter.spreadAngle / 2f),
				targetShooter.spreadAngle,
				HandleUtility.GetHandleSize(targetShooter.transform.position) * 1.5f);
		}
	}

}
