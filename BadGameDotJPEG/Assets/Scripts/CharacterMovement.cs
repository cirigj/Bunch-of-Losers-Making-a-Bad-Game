using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BulletShooter))]
public class CharacterMovement : MonoBehaviour
{
    public bool focus;
    public float speed;
    public float focusSpeed;
    public float horizontal;
    public float vertical;
    public Rigidbody2D rb;
	public Animator animator;

	public float timeBetweenShots = 0.1f;
	bool canShoot;
	public float spreadAngle = 60f;
	public float focusAngle = 30f;
	public int bullets = 3;
	public float bulletSpeed;

	BulletShooter shooter;

	void Awake () {
        rb = GetComponent<Rigidbody2D>();
		shooter = GetComponent<BulletShooter>();
		canShoot = true;
    }
	
	void Update () {
		focus = Globals.Inputs.Focus;

        if (focus)
            rb.velocity = new Vector2(Globals.Inputs.Horizontal * focusSpeed, Globals.Inputs.Vertical * focusSpeed);
        else
            rb.velocity = new Vector2(Globals.Inputs.Horizontal * speed, Globals.Inputs.Vertical * speed);

		animator.SetBool("Focus", focus);
		animator.SetInteger("Horizontal", Mathf.RoundToInt(rb.velocity.x));

		if (Globals.Inputs.Fire) {
			if (canShoot) {
				canShoot = false;
				ActionData data = new ActionData();
				data.bullets = bullets;
				if (focus) {
					shooter.spreadAngle = focusAngle;
				}
				else {
					shooter.spreadAngle = spreadAngle;
				}
				data.speed = bulletSpeed;
				shooter.StartCoroutine(shooter.Buckshot(data));
				StartCoroutine(WaitToShoot());
			}
		}
	}

	IEnumerator WaitToShoot () {
		yield return new WaitForSeconds(timeBetweenShots);
		canShoot = true;
		yield break;
	}

}
