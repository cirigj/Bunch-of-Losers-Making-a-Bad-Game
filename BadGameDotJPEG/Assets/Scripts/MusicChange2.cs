using UnityEngine;
using System.Collections;

public class MusicChange2 : MonoBehaviour
{
    void Start()
    {
        SoundManager.singleton.music.clip = SoundManager.singleton.BossTheme2;
        SoundManager.singleton.music.Play();
    }

}
