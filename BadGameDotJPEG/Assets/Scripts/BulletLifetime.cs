using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletLifetime : MonoBehaviour {

	public float lifetime;
	Rigidbody2D rb;

	void Awake () {
		StartCoroutine(Decay());
		rb = GetComponent<Rigidbody2D>();
	}

	void Start () {
		if (rb.velocity != Vector2.zero) {
			transform.right = rb.velocity;
		}
	}

	IEnumerator Decay () {
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
		yield break;
	}

}
