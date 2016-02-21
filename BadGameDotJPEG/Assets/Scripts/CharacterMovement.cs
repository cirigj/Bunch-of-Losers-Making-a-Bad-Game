using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public bool focus;
    public float speed;
    public float focusSpeed;
    public float horizontal;
    public float vertical;
    public Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        if (focus)
            rb.velocity = new Vector2(Globals.Inputs.Horizontal * focusSpeed, Globals.Inputs.Vertical * focusSpeed);
        else
            rb.velocity = new Vector2(Globals.Inputs.Horizontal * speed, Globals.Inputs.Vertical * speed);
    }
}
