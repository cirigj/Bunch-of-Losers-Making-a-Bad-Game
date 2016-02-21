using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioClip hitmarker;
    public AudioClip shoot;
    public AudioClip explosion;

    public AudioClip StageTheme;
    public AudioClip BossTheme;
    public AudioClip BossTheme2;

    public AudioSource music;
    public AudioSource player;
    public AudioSource enemy;

	void Start ()
    {
        music.clip = StageTheme;
	}
	
	void Update () {
	
	}
}
