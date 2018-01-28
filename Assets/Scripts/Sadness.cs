using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sadness : MonoBehaviour {

    public PatrolMonster[] monsters;

    public float WailOffTime = 7;
    public float WailOnTime = 5;

    public bool wailActive = false;

	// Use this for initialization
	void Start () {
        monsters = FindObjectsOfType<PatrolMonster>();
        print("yay");
        StartCoroutine("WailForSeconds");
        print("yay2");
	}
	
	// Update is called once per frame
	void Update () {
		


	}

    void FreezeAllMonsters(bool frozen = true)
    {
        foreach (PatrolMonster monster in monsters)
        {
            monster.Activate(new PowerEventData(frozen, transform.position, 500));
        }
    }

    void SwapWail()
    {
        print("wail");
        if (wailActive)
        {
            FreezeAllMonsters(false);
            wailActive = false;
        }
        else
        {
            FreezeAllMonsters(true);
            wailActive = true;
        }
    }

    IEnumerator WailForSeconds()
    {
        print("gogo");
        while (true)
        {
            if (wailActive)
            {
                print("wait for wailtime");
                yield return new WaitForSeconds(WailOnTime);
            }
            else
            {
                print("wait for wailofftime");
                yield return new WaitForSeconds(WailOffTime);
            }
            SwapWail();
        }
    }
}
