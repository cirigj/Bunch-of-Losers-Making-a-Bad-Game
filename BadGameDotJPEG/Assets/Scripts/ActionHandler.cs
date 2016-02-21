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

	public float waitTime; //Wait, MoveToPosition, MoveRelative, FireClockwise, FireAntiClockwise, Buckshot, FireAtTarget
	public bool waitForFinish; //MoveToPosition, MoveRelative, FireClockwise, FireAntiClockwise, Buckshot, FireAtTarget
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

	public Coroutine actionCoroutine;

	public WaveManager waveManager;

	void Awake () {
		shooter = GetComponent<BulletShooter>();
		stats = GetComponent<EnemyStats>();
	}

	public void StartActions () {
		actionCoroutine = StartCoroutine(HandleActions());
	}

	public void StopActions () {
		if (actionCoroutine != null) {
			StopCoroutine(actionCoroutine);
		}
		actionCoroutine = null;
	}

	IEnumerator HandleActions () {
		for (int i = 0; i < actions.Count; i++) {
			switch (actions[i].type) {
			case ActionData.Type.Wait:
				yield return new WaitForSeconds(actions[i].waitTime);
				break;
			case ActionData.Type.MoveToPosition:
				if (actions[i].speed != 0f) {
					stats.maxVel = actions[i].speed;
				}
				if (actions[i].waitForFinish) {
					yield return stats.StartCoroutine(stats.Movement((Vector2)actions[i].position));
				}
				else {
					stats.StartCoroutine(stats.Movement((Vector2)actions[i].position));
					yield return new WaitForSeconds(actions[i].waitTime);
				}
				break;
			case ActionData.Type.MoveRelative:
				if (actions[i].speed != 0f) {
					stats.maxVel = actions[i].speed;
				}
				if (actions[i].waitForFinish) {
					yield return stats.StartCoroutine(stats.Movement((Vector2)(actions[i].position + transform.position)));
				}
				else {
					stats.StartCoroutine(stats.Movement((Vector2)(actions[i].position + transform.position)));
					yield return new WaitForSeconds(actions[i].waitTime);
				}
				break;
			case ActionData.Type.FireClockwise:
				if (actions[i].waitForFinish) {
					yield return shooter.StartCoroutine(shooter.FireClockwise(actions[i]));
				}
				else {
					shooter.StartCoroutine(shooter.FireClockwise(actions[i]));
					yield return new WaitForSeconds(actions[i].waitTime);
				}
				break;
			case ActionData.Type.FireAntiClockwise:
				if (actions[i].waitForFinish) {
					yield return shooter.StartCoroutine(shooter.FireAntiClockwise(actions[i]));
				}
				else {
					shooter.StartCoroutine(shooter.FireAntiClockwise(actions[i]));
					yield return new WaitForSeconds(actions[i].waitTime);
				}
				break;
			case ActionData.Type.AimAtPosition:
				shooter.AimAtPosition(actions[i].position);
				break;
			case ActionData.Type.LockOnTarget:
				//shooter.lockTarget = actions[i].target;
				shooter.lockTarget = WaveManager.singleton.player;
				break;
			case ActionData.Type.UnlockTarget:
				shooter.lockTarget = null;
				break;
			case ActionData.Type.Buckshot:
				if (actions[i].waitForFinish) {
					yield return shooter.StartCoroutine(shooter.Buckshot(actions[i]));
				}
				else {
					shooter.StartCoroutine(shooter.Buckshot(actions[i]));
					yield return new WaitForSeconds(actions[i].waitTime);
				}
				break;
			case ActionData.Type.FireAtTarget:
				if (actions[i].waitForFinish) {
					yield return shooter.StartCoroutine(shooter.FireAtTarget(actions[i]));
				}
				else {
					shooter.StartCoroutine(shooter.FireAtTarget(actions[i]));
					yield return new WaitForSeconds(actions[i].waitTime);
				}
				break;
			case ActionData.Type.StartLoopHere:
				//Do nothing
				break;
			case ActionData.Type.LoopActions:
				int newIndex = -1;
				for (int j = 0; j < i; j++) {
					if (actions[j].type == ActionData.Type.StartLoopHere) {
						newIndex = j;
						actions[j].numberOfLoops--;
						if (actions[j].numberOfLoops <= 0) {
							newIndex--;
							actions.RemoveAt(j);
							i--;
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
		actionCoroutine = null;
		yield break;
	}

	void OnDestroy () {
		waveManager.currentWave.Remove(this);
		StopActions();
	}

}
