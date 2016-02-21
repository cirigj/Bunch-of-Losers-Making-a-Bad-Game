using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpeningCinema : MonoBehaviour
{
    Text t;
    public AudioSource a;
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
            "\nThe vaporwave statue, Helios, attempts to steal \nskeleton embryos. Critical security systems are \nshut down and it now becomes a race for survival \nwith skeletons roaming freely over the island.",
            "\nYou must defeat\r\r\r\r\r\r\r\0\0\0\0\0\0\r\r\r\r\r\rsurvive against the skeletons.",
            "\nOr else you",
            "\r",
            "will",
            "\r",
            "die.",
            "\n\nPress Z to continue."
        };
        storySpeed = new float[]
        {
            5f,
            5f,
            5f,
            8f,
            8f,
            8f,
            8f,
            15f,
            5f
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
        }
        else if (storyDelay == storySpeed[storyNum] && storyProgress == storyBoard[storyNum].Length)
        {
            storyNum++;
            storyProgress = 0;
            storyDelay = 0;
            if (storyNum != storyBoard.Length)
                t.text = t.text.Substring(0, t.text.Length - 1) + "\n\n";
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
            }
            else
            {
                t.text = t.text.Substring(0, t.text.Length - 1) + storyBoard[storyNum][storyProgress] + "_";
            }
            storyProgress++;
            storyDelay = 0;
        }
        else
        {
            storyDelay++;
        }
	}
}

