using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public bool focus;
    public float speed;
    public float focusSpeed;
    public float horizontal;
    public float vertical;
    public Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
		focus = Globals.Inputs.Focus;

        if (focus)
            rb.velocity = new Vector2(Globals.Inputs.Horizontal * focusSpeed, Globals.Inputs.Vertical * focusSpeed);
        else
            rb.velocity = new Vector2(Globals.Inputs.Horizontal * speed, Globals.Inputs.Vertical * speed);
    }
}
