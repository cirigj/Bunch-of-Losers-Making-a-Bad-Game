using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ActionData {

	public enum Type {
		Wait = 0,
		MoveToPosition = 1,
		MoveRelative = 2,
		FireClockwise = 3,
		FireAntiClockwise = 4,
		AimAtPosition = 5,
		LockOnTarget = 6,
		UnlockTarget = 7,
		Buckshot = 8,
		FireAtTarget = 9,
		StartLoopHere = 10,
		LoopActions = 11,
		Destroy = 12,
		ChangeAngle = 13,
	}

	public Type type;

	public float waitTime; //Wait
	public Vector3 position; //MoveToPosition, MoveRelative, AimAtPosition
	public float speed; //MoveToPosition, MoveRelative, FireClockwise, FireAntiClockwise, Buckshot, FireAtTarget
	public int bullets; //FireClockwise, FireAntiClockwise, Buckshot, FireAtTarget
	public float timeBetweenShots; //FireClockwise, FireAntiClockwise, Buckshot, FireAtTarget
	public Transform target; //LockOnTarget
	public int numberOfLoops; //LoopActions
	public float angle; //ChangeAngle

}

[RequireComponent(typeof(BulletShooter))]
public class ActionHandler : MonoBehaviour {

	public List<ActionData> actions;

	void Start () {
	
	}

	void Update () {
	
	}
}
