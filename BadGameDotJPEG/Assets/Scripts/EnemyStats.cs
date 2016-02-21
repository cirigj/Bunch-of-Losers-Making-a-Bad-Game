using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    public float health;
    public float maxVel;
    public float acc;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
  
    public IEnumerator Movement(Vector2 target)
    {
        rb.velocity = Vector3.zero;
        Vector2 dislocation = target - (Vector2)transform.position;
        Vector2 unit = dislocation / dislocation.magnitude;
        while(true)
        {
            dislocation = target - (Vector2)transform.position;
            rb.velocity = rb.velocity + (Vector3)unit * acc;
            if (rb.velocity.magnitude > maxVel)
                rb.velocity = unit * maxVel;
            if (dislocation.magnitude < rb.velocity.magnitude *Time.deltaTime)
            {
                transform.position = target;
                rb.velocity = Vector3.zero;
                yield break;
            }
            yield return true;
        }
    }

}
