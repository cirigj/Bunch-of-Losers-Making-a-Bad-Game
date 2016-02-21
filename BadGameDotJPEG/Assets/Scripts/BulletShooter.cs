using UnityEngine;
using System.Collections;

public class BulletShooter : MonoBehaviour {

	public float spreadAngle = 30f;
	public Vector3 direction = -Vector3.right;
	public Transform lockTarget;

	public Rigidbody2D bulletPrefab;

	void Awake () {
		
	}

	void Update () {
		if (lockTarget != null) {
			AimAtPosition(lockTarget.position);
		}
		Debug.DrawRay(transform.position, direction * 3f, Color.blue);
	}

	public void AimAtPosition (Vector3 position) {
		position = new Vector3(position.x, position.y, transform.position.z + 10000f); //WHY DOES THIS WORK???
		Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);
		direction = newRotation * -Vector3.up;
		direction.Normalize();
	}

	public IEnumerator FireClockwise (ActionData data) {
		for (int i = 0; i < data.bullets; i++) {
			FireBullet((Quaternion.AngleAxis((spreadAngle * (float)i / (float)(data.bullets - 1) - (spreadAngle / 2f)), transform.forward) * direction).normalized, data.speed);
			yield return new WaitForSeconds(data.timeBetweenShots);
		}
		yield break;
	}

	public IEnumerator FireAntiClockwise (ActionData data) {
		for (int i = 0; i < data.bullets; i++) {
			FireBullet((Quaternion.AngleAxis((-spreadAngle * (float)i / (float)(data.bullets - 1) + (spreadAngle / 2f)), transform.forward) * direction).normalized, data.speed);
			yield return new WaitForSeconds(data.timeBetweenShots);
		}
		yield break;
	}

	public IEnumerator Buckshot (ActionData data) {
		for (int i = 0; i < data.bullets; i++) {
			FireBullet((Quaternion.AngleAxis((spreadAngle * (float)i / (float)(data.bullets - 1) - (spreadAngle / 2f)), transform.forward) * direction).normalized, data.speed);
		}
		yield break;
	}

	public IEnumerator FireAtTarget (ActionData data) {
		for (int i = 0; i < data.bullets; i++) {
			FireBullet(direction, data.speed);
			yield return new WaitForSeconds(data.timeBetweenShots);
		}
		yield break;
	}

	public void FireBullet (Vector3 direction, float speed) {
		Rigidbody2D newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Rigidbody2D;
		newBullet.velocity = direction * speed;
	}

}
