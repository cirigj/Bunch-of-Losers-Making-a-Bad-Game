using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
	void Update ()
    {
        Globals.Inputs.Horizontal = Input.GetAxisRaw("Horizontal");
        Globals.Inputs.Vertical = Input.GetAxisRaw("Vertical");
        Globals.Inputs.Bomb = Input.GetButtonDown("Bomb");
        Globals.Inputs.Fire = Input.GetButton("Fire");
        Globals.Inputs.Focus = Input.GetButton("Focus");
	}
}
