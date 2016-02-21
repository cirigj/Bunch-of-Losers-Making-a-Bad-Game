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
