using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpeningCinema : MonoBehaviour
{
    Text t;
    string[] storyBoard;
    float[] storySpeed;
    int storyNum;
    int storyProgress;
    int storyDelay;
	void Start ()
    {
        t = GetComponent<Text>();
        storyBoard = new string[]
        {
            "\nHuge advancements in vaporwave aesthetic have \nenabled an artist to create an island full of \nliving skeletons.",
            "\nThe vaporwave statue, Helios attempts to steal \nskeleton embryos. Critical security systems are \nshut down and it now becomes a race for survival \nwith skeletons roaming freely over the island.",
            "\nYou must survive against the skeletons.",
            "\nOr else you",
            "  ",
            "will",
            "  ",
            "die."
        };
        storySpeed = new float[]
        {
            3f,
            3f,
            5f,
            5f,
            4f,
            5f,
            4f,
            10f
        };

        storyNum = 0;
        storyProgress = 0;
        storyDelay = 0;
	}
	
	void Update ()
    {
        if(storyNum == storyBoard.Length)
        {
            //End Scene
        }
	    if(storyDelay == storySpeed[storyNum] && storyProgress == storyBoard[storyNum].Length)
        {
            storyNum++;
            storyProgress = 0;
            storyDelay = 0;
            t.text += "\n\n";
        }
        else if(storyProgress == 0)
        {
            if(storyDelay == 15)
            {
                t.text += storyBoard[storyNum][storyProgress];
                storyProgress++;
                storyDelay = 0;
            }
            else
            {
                storyDelay++;
            }
        }
        else if(storyDelay == storySpeed[storyNum])
        {
            t.text += storyBoard[storyNum][storyProgress];
            storyProgress++;
            storyDelay = 0;
        }
        else
        {
            storyDelay++;
        }
	}
}

