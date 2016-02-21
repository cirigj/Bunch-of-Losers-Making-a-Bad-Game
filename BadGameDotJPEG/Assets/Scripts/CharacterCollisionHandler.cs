using UnityEngine;
using System.Collections;

public class CharacterCollisionHandler : MonoBehaviour
{
    CharacerStats cs;
    void Start()
    {
        cs = GetComponent<CharacerStats>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            cs.StartDeathRoutine();
            Destroy(other.gameObject);
        }
        else if(other.tag == "Laser")
        {
            cs.StartDeathRoutine();
        }
    }
}
