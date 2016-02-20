using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomEditor(typeof(BulletShooter))]
public class BulletShooterEditor : Editor {

	BulletShooter targetShooter;

	void OnSceneGUI () {
		targetShooter = (BulletShooter)target;
	}

}
