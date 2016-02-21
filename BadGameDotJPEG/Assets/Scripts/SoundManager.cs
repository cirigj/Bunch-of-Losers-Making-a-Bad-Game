using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager singleton;
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
        if(singleton == null)
        {
            singleton = this;
        }
        music.clip = StageTheme;
        music.Play();
	}
	
	
    public void playerFire()
    {
        if (!player.isPlaying)
        {
            player.clip = shoot;
            player.Play();
        }
    }

    public void enemyHit()
    {
        if (!enemy.isPlaying)
        {
            enemy.clip = hitmarker;
            enemy.Play();
        }
    }

    public void enemyDead()
    {
        enemy.clip = explosion;
        enemy.Play();
    }
}
