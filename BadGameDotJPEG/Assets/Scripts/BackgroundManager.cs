using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour {

    public GameObject[] BackgroundObjects;
    List<GameObject> MovingObjects;

	void Awake ()
    {
        MovingObjects = new List<GameObject>();
        Camera cam = Camera.main;
        Globals.camHeight = 2f * cam.orthographicSize;
        Globals.camWidth = Globals.camHeight * cam.aspect;
    }
	
	void Update ()
    {
	    if(MovingObjects.Count == 0)
        {
            int r = Random.Range(0, BackgroundObjects.Length);
            
        }
	}
}
