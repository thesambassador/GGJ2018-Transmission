using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear : MonoBehaviour {

    public OnOffWall[] walls;

    public float WailOffTime = 7;
    public float WailOnTime = 5;

    public bool wailActive = false;

    Animator _animator;

    // Use this for initialization
    void Start()
    {
        walls = FindObjectsOfType<OnOffWall>();
        //print("yay");
        _animator = GetComponent<Animator>();
        StartCoroutine("WailForSeconds");
        //print("yay2");

        
    }

    // Update is called once per frame
    void Update()
    {



    }

    void FreezeAllMonsters(bool frozen = true)
    {
        foreach (OnOffWall wall in walls)
        {
            wall.Activate(new PowerEventData(frozen, transform.position, 500));
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
                _animator.SetBool("play", false);
                yield return new WaitForSeconds(WailOnTime);
            }
            else
            {
                _animator.SetBool("play", true);
                print("wait for wailofftime");
                yield return new WaitForSeconds(WailOffTime);
            }
            SwapWail();
        }
    }
}
