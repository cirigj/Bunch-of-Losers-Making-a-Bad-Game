using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SpawnData {

	public enum Side {
		Side,
		Top,
		Bottom,
	}

	public ActionHandler enemyPrefab;
	public Side side;
	[Range(-1f, 1f)]
	public float position;

}

[System.Serializable]
public class EnemyWave {
	
	public List<SpawnData> enemies;
	public float waitTime;

}

public class WaveManager : MonoBehaviour {

	public float topBuffer = 1f;
	public float bottomBuffer = 1f;
	public float sideBuffer = 1f;

	public float spawnDepth = 0f;

	public List<EnemyWave> waves;
	public List<ActionHandler> currentWave;

	void Start () {
		StartCoroutine(SpawnWaves());
	}

	IEnumerator SpawnWaves () {
		for (int i = 0; i < waves.Count; i++) {
			yield return StartCoroutine(HandleWave(waves[i]));
			yield return new WaitForSeconds(waves[i].waitTime);
		}
		yield break;
	}

	IEnumerator HandleWave (EnemyWave wave) {
		currentWave = new List<ActionHandler>();
		for (int i = 0; i < wave.enemies.Count; i++) {
			SpawnEnemy(wave.enemies[i]);
		}
		while (true) {
			bool readyToBreak = true;
			for (int i = 0; i < currentWave.Count; i++) {
				if (currentWave[i].actionCoroutine != null) {
					readyToBreak = false;
					break;
				}
			}
			if (readyToBreak) {
				yield break;
			}
			else {
				yield return null;
			}
		}
		yield break;
	}

	void SpawnEnemy (SpawnData data) {
		if (data.enemyPrefab == null) {
			return;
		}
		ActionHandler newEnemy = Instantiate(data.enemyPrefab, GetStartPosition(data), Quaternion.identity) as ActionHandler;
		newEnemy.StartActions();
		newEnemy.waveManager = this;
		currentWave.Add(newEnemy);
	}

	Vector3 GetStartPosition (SpawnData data) {
		float x = 0f;
		float y = 0f;
		float z = spawnDepth;
		if (data.side == SpawnData.Side.Side) {
			x = Camera.main.transform.position.x + Globals.camWidth / 2f + sideBuffer;
			y = (Globals.camHeight / 2f) * data.position;
		}
		if (data.side == SpawnData.Side.Bottom || data.side == SpawnData.Side.Top) {
			x = (Globals.camWidth / 2f) * data.position;
			if (data.side == SpawnData.Side.Bottom) {
				y = Camera.main.transform.position.y - Globals.camHeight / 2f - bottomBuffer;
			}
			if (data.side == SpawnData.Side.Top) {
				y = Camera.main.transform.position.y + Globals.camHeight / 2f + topBuffer;
			}
		}
		return new Vector3(x, y, z);
	}

}
