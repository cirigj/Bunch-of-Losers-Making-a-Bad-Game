﻿using UnityEngine;
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
	public float timeBetweenShots; //FireClockwise, FireAntiClockwise, FireAtTarget
	public Transform target; //LockOnTarget
	public int numberOfLoops; //LoopActions
	public float angle; //ChangeAngle

}

[RequireComponent(typeof(BulletShooter))]
[RequireComponent(typeof(EnemyStats))]
public class ActionHandler : MonoBehaviour {

	public List<ActionData> actions;
	private int actionIndex;

	private BulletShooter shooter;
	private EnemyStats stats;

	private Coroutine actionCoroutine;

	void Awake () {
		shooter = GetComponent<BulletShooter>();
		stats = GetComponent<EnemyStats>();
	}

	void Start () {
		StartActions();
	}

	void Update () {
		
	}

	void StartActions () {
		actionCoroutine = StartCoroutine(HandleActions());
	}

	void StopActions () {
		StopCoroutine(actionCoroutine);
		actionCoroutine = null;
	}

	IEnumerator HandleActions () {
		for (int i = 0; i < actions.Count; i++) {
			switch (actions[i].type) {
			case ActionData.Type.Wait:
				yield return new WaitForSeconds(actions[i].waitTime);
				break;
			case ActionData.Type.MoveToPosition:
				stats.maxVel = actions[i].speed;
				yield return stats.StartCoroutine(stats.Movement((Vector2)actions[i].position));
				break;
			case ActionData.Type.MoveRelative:
				stats.maxVel = actions[i].speed;
				yield return stats.StartCoroutine(stats.Movement((Vector2)(actions[i].position + transform.position)));
				break;
			case ActionData.Type.FireClockwise:
				yield return shooter.StartCoroutine(shooter.FireClockwise(actions[i]));
				break;
			case ActionData.Type.FireAntiClockwise:
				yield return shooter.StartCoroutine(shooter.FireAntiClockwise(actions[i]));
				break;
			case ActionData.Type.AimAtPosition:
				shooter.AimAtPosition(actions[i].position);
				break;
			case ActionData.Type.LockOnTarget:
				shooter.lockTarget = actions[i].target;
				break;
			case ActionData.Type.UnlockTarget:
				shooter.lockTarget = null;
				break;
			case ActionData.Type.Buckshot:
				yield return shooter.StartCoroutine(shooter.Buckshot(actions[i]));
				break;
			case ActionData.Type.FireAtTarget:
				yield return shooter.StartCoroutine(shooter.FireAtTarget(actions[i]));
				break;
			case ActionData.Type.StartLoopHere:
				//Do nothing
				break;
			case ActionData.Type.LoopActions:
				int newIndex = -1;
				for (int j = 0; j < actions.Count; j++) {
					if (actions[j].type == ActionData.Type.StartLoopHere) {
						newIndex = j;
						actions[j].numberOfLoops--;
						if (actions[j].numberOfLoops <= 0) {
							newIndex--;
							actions.RemoveAt(j);
						}
					}
				}
				actions[i].numberOfLoops--;
				if (actions[i].numberOfLoops <= 0) {
					actions.RemoveAt(i);
				}
				i = newIndex;
				break;
			case ActionData.Type.Destroy:
				Destroy(gameObject);
				break;
			case ActionData.Type.ChangeAngle:
				shooter.spreadAngle = actions[i].angle;
				break;
			}
		}
		yield break;
	}

}
