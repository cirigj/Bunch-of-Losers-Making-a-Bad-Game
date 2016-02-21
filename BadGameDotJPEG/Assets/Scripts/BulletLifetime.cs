using UnityEngine;
using System.Collections;

public class BulletLifetime : MonoBehaviour {

	public float lifetime;

	void Awake () {
		StartCoroutine(Decay());
	}

	IEnumerator Decay () {
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
		yield break;
	}

}
