using UnityEngine;
using System.Collections;

public class MusicChange : MonoBehaviour
{    
	void Start ()
    {
        SoundManager.singleton.music.clip = SoundManager.singleton.BossTheme;
        SoundManager.singleton.music.Play();
    }
	
}
