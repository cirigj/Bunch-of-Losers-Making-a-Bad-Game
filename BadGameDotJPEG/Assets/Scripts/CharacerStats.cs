using UnityEngine;
using System.Collections;

public class CharacerStats : MonoBehaviour
{
    public int Lives;
    public int Bombs;
    private bool hit;
    private int hitCounter;

	void Start ()
    {
        Lives = Globals.BaseLives;
        Bombs = Globals.BaseBombs;
        hit = false;
	}
	
	void Update ()
    {
	    
	}

    void Death()
    {

    }

    public void StartDeathRoutine()
    {
        hit = true;
        hitCounter = 0;
    }

    IEnumerator DeathRoutine()
    {
        hitCounter += 1;
        if(Globals.Inputs.Bomb)
        {
            yield break;
        }
        if(hitCounter == 3)
        {
            Death();
            yield break;
        }
        yield return new WaitForFixedUpdate();
    }
}
