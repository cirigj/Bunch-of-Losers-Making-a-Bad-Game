using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomEditor(typeof(BulletShooter))]
public class BulletShooterEditor : Editor {

	BulletShooter targetShooter;
	Vector3 normal;
	Vector3 direction;
	Vector3 directionOrthag;

	void OnSceneGUI () {
		
		targetShooter = (BulletShooter)target;

		if (targetShooter.direction == Vector3.zero) {
			targetShooter.direction = -Vector3.right;
		}
		targetShooter.direction.Normalize();

		normal = targetShooter.transform.forward;
		direction = targetShooter.transform.rotation * targetShooter.direction;
		directionOrthag = Quaternion.AngleAxis(-90f, normal) * direction;
		//***ADD HANDLE FOR ROTATION OF DIRECTION***

		//***HOOK INTO UNDO STACK***
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
