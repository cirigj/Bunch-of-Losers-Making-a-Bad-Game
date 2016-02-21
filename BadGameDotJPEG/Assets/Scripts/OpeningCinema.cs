using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class OpeningCinema : MonoBehaviour
{
    Text t;
    public AudioSource a;
    public AudioSource keys;
    public AudioClip[] keypress;
    public AudioClip spacepress;
    string[] storyBoard;
    float[] storySpeed;
    int storyNum;
    int storyProgress;
    int[] storyDelays;
    int storyDelay;
	void Start ()
    {
        a.Play();
        t = GetComponent<Text>();
        storyBoard = new string[]
        {
            "\nHuge advancements in vaporwave aesthetic have \nenabled an artist to create an island full of \nliving skeletons.",
            "\nThe vaporwave statue, Helios, attempts to steal \nskeleton embryos.\r\r\r\r\r\r\r\r Critical security systems are \nshut down and it now becomes a race for survival \nwith skeletons roaming freely over the island.",
            "\nSnoop Dogg\r\r\r\r\r\r\r\r\r\r\r, you must defeat\r\r\r\r\r\r\r\0\0\0\0\0\0\r\r\r\r\r\rsurvive\r\r\r\r\r\r\r\r\r against the skeletons.",
            "\nOr else you",
            "\r",
            "will",
            "\r",
            "die.",
            "\n\nPress Z to continue."
        };
        storySpeed = new float[]
        {
            4f,
            4f,
            4f,
            7f,
            7f,
            7f,
            7f,
            15f,
            4f
        };
        storyDelays = new int[]
        {
            60,
            30,
            60,
            90,
            30,
            30,
            30,
            30,
            120
        };
        storyNum = 0;
        storyProgress = 0;
        storyDelay = 0;
	}
	
	void Update ()
    {
        if (storyNum == storyBoard.Length)
        {
            string s = (storyDelay / 20) % 2 == 0 ? "_" : "▇";
            t.text = t.text.Substring(0, t.text.Length - 1) + s;
            storyDelay++;
            if (storyDelay == 40)
            {
                storyDelay = 0;
            }

            if (Input.GetButton("Fire"))
            {
                SceneManager.LoadScene(1);
            }
        }
        else if (storyDelay == storySpeed[storyNum] && storyProgress == storyBoard[storyNum].Length)
        {
            storyNum++;
            storyProgress = 0;
            storyDelay = 0;
            if (storyNum != storyBoard.Length)
            {
                t.text = t.text.Substring(0, t.text.Length - 1) + "\n\n";
                keys.clip = keypress[Random.Range(0, keypress.Length - 1)];
                keys.Play();
            }
        }
        else if (storyProgress == 0)
        {
            if (storyDelay == storyDelays[storyNum])
            {
                t.text = t.text.Substring(0, t.text.Length - 1) + storyBoard[storyNum][storyProgress] + "_";
                storyProgress++;
                storyDelay = 0;
            }
            else
            {
                string s = (storyDelay / 20) % 2 == 0 ? "_" : "▇";
                t.text = t.text.Substring(0, t.text.Length - 1) + s;
                storyDelay++;
            }
        }
        else if (storyDelay == storySpeed[storyNum])
        {
            if (storyBoard[storyNum][storyProgress] == '\r')
            {
                //skip
            }
            else if (storyBoard[storyNum][storyProgress] == '\0')
            {
                t.text = t.text.Substring(0, t.text.Length - 2) + "_";
                keys.clip = keypress[0];
                keys.Play();
            }
            else
            {
                if (storyBoard[storyNum][storyProgress] == ' ')
                    keys.clip = spacepress;
                else
                    keys.clip = keypress[Random.Range(0, keypress.Length)];
                keys.Play();
                t.text = t.text.Substring(0, t.text.Length - 1) + storyBoard[storyNum][storyProgress] + "_";
            }
            storyProgress++;
            storyDelay = 0;
        }
        else
        {
            if (storyProgress < storyBoard[storyNum].Length && storyBoard[storyNum][storyProgress] == '\r')
            {
                string s = ((int)((storyProgress * storySpeed[storyNum] + storyDelay) / 20)) % 2 == 0 ? "_" : "▇";
                t.text = t.text.Substring(0, t.text.Length - 1) + s;
            }
            storyDelay++;
            if (Input.GetButton("Fire"))
            {
                storyDelay = (int)storySpeed[storyNum];
            }
        }
	}
}

