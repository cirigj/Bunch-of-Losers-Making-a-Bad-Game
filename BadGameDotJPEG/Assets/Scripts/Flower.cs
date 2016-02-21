using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
	void FixedUpdate ()
    {
        transform.RotateAround(Vector3.forward, .1f);
	}
}
