using UnityEngine;
using System.Collections;

public class HitMarker : MonoBehaviour
{
    int DeleteIn;
    void Start()
    {
        DeleteIn = 0;
    }

    void Update()
    {
        if (DeleteIn == 4)
            Destroy(gameObject);
        DeleteIn++;
    }
}
