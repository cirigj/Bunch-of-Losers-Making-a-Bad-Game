using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour {

    public GameObject[] BackgroundObjects;
    public GameObject Background;
    GameObject[] Backgrounds;
    List<GameObject> MovingObjects;
    public float[] depths;
    public float baseSpeed;
    public GameObject hitmarker;
    public GameObject explosion;

	void Awake ()
    {
        MovingObjects = new List<GameObject>();
    }

    void Start()
    {
        Backgrounds = new GameObject[2];
        Backgrounds[0] = Instantiate(Background, new Vector3(0f, 0f, 10f), Quaternion.identity) as GameObject;
        Backgrounds[1] = Instantiate(Background, new Vector3(18, 0f, 10.1f), Quaternion.identity) as GameObject;
        Backgrounds[0].GetComponent<Rigidbody2D>().velocity = new Vector3(-1f, 0f, 0f);
        Backgrounds[1].GetComponent<Rigidbody2D>().velocity = new Vector3(-1f, 0f, 0f);
    }
	
	void Update ()
    {
        foreach(GameObject bg in Backgrounds)
        {
            if(bg.transform.position.x < -18)
            {
                bg.transform.position = new Vector3(18, 0f, 10f);
            }
        }
	    if(MovingObjects.Count == 0)
        {
            Create();
        }

        if(Random.Range(0, 1000) == 0)
        {
            Create();
        }

        List<GameObject> toRemove = new List<GameObject>();
        foreach(GameObject go in MovingObjects)
        {
            Sprite s = go.GetComponent<SpriteRenderer>().sprite;
            if (go.transform.position.x < -Globals.camWidth / 2f - (s.textureRect.width / 2f) / s.pixelsPerUnit)
            {
                toRemove.Add(go);
            }  
        }
        foreach(GameObject go in toRemove)
        {
            MovingObjects.Remove(go);
            Destroy(go);
        }
	}

    void Create()
    {
        int r = Random.Range(0, BackgroundObjects.Length);
        Sprite s = BackgroundObjects[r].GetComponent<SpriteRenderer>().sprite;
        Rect rect = s.textureRect;
        float h = rect.height / s.pixelsPerUnit;
        float w = rect.width / s.pixelsPerUnit;
        float depth = depths[Random.Range(0, depths.Length)];
        GameObject n = Instantiate
        (
            BackgroundObjects[r],
            new Vector3
            (
                Globals.camWidth / 2f + w / 2f,
                Random.Range(-Globals.camHeight / 2f + h / 2f, Globals.camHeight / 2f - h / 2f),
                depth
            ),
            Quaternion.identity
        ) as GameObject;


        n.transform.localScale = new Vector3(1f / depth, 1f / depth, 1f);
        n.GetComponent<Rigidbody2D>().velocity = new Vector3(-baseSpeed / depth, 0f, 0f);
        MovingObjects.Add(n);
    }

    public void Hit(Vector3 pos)
    {
        Instantiate(hitmarker, pos, Quaternion.identity);
    }

    public void Death(Vector3 pos)
    {
        Instantiate(explosion, pos, Quaternion.identity);
    }
}
