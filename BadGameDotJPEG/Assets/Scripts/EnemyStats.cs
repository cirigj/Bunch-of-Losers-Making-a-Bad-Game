using UnityEngine;
using System.Collections;
[ RequireComponent(typeof(Rigidbody2D)) ]
[ RequireComponent(typeof(Collider2D)) ]

public class EnemyStats : MonoBehaviour
{
    public float health;
    public float maxVel;
    public float acc = 0.1f;
    public Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player Bullet")
        {
            Debug.Log("hello");
            health -= 1;
            if (health <= 0)
                Death();
            else
                Hit(other.transform);
        }
    }

    void Hit(Transform t)
    {
        Camera.main.GetComponent<SoundManager>().enemyHit();
        BackgroundManager.singleton.Hit(t.position);
        Destroy(t.gameObject);
    }

    void Death()
    {
        BackgroundManager.singleton.Death(transform.position);
        Destroy(gameObject);
    }

    public IEnumerator Movement(Vector2 target)
    {
        rb.velocity = Vector3.zero;
        Vector2 dislocation = target - (Vector2)transform.position;
		Vector2 unit = dislocation.normalized;
        while(true)
        {
            dislocation = target - (Vector2)transform.position;
            rb.velocity = rb.velocity + (Vector2)unit * acc;
            if (rb.velocity.magnitude > maxVel)
                rb.velocity = unit * maxVel;
            if (dislocation.magnitude < rb.velocity.magnitude *Time.deltaTime)
            {
                transform.position = target;
                rb.velocity = Vector3.zero;
                yield break;
            }
            yield return null;
        }
    }

}
