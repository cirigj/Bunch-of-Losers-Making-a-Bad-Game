using UnityEngine;
using System.Collections;

public class Glasses : MonoBehaviour {
    
    void Start()
    {
        StartCoroutine(move());
    }

	IEnumerator move()
    {
        
        Vector3 goal = transform.parent.position;
        Vector3 delta = (goal - transform.position) * Time.deltaTime / 5f;
        while(true)
        {

            if ((goal - transform.position).magnitude < delta.magnitude)
            {
                transform.position = transform.parent.position;
                yield break;
            }
            else
            {
                Debug.Log(delta);
                transform.position += delta;
            }
            yield return new WaitForFixedUpdate();
           
        }
    }
}
