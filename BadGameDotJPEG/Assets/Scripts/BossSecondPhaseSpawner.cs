using UnityEngine;
using System.Collections;

public class BossSecondPhaseSpawner : MonoBehaviour {

	public ActionHandler secondPhasePrefab;
	public ActionHandler actionHandler;

	void OnDestroy () {
		ActionHandler secondPhase = Instantiate(secondPhasePrefab, transform.position, Quaternion.identity) as ActionHandler;
		secondPhase.waveManager = WaveManager.singleton;
		secondPhase.waveManager.currentWave.Add(secondPhase);
		secondPhase.StartActions();
	}

}
