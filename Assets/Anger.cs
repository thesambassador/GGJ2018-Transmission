using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anger : MonoBehaviour {

    public MoveObjectOnPower[] walls;

    public float WailOffTime = 7;
    public float WailOnTime = 5;

    public bool wailActive = false;

    Animator _animator;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        walls = FindObjectsOfType<MoveObjectOnPower>();
        //print("yay");
        StartCoroutine("WailForSeconds");
        //print("yay2");
        
        
    }

    // Update is called once per frame
    void Update()
    {



    }

    void FreezeAllMonsters(bool frozen = true)
    {
        foreach (MoveObjectOnPower wall in walls)
        {
            wall.Activate(new PowerEventData(frozen, transform.position, 500));
        }
    }

    void SwapWail()
    {
        print("wail");
        if (wailActive)
        {
            _animator.SetBool("play", false);
            FreezeAllMonsters(false);
            wailActive = false;
        }
        else
        {
            _animator.SetBool("play", true);
            FreezeAllMonsters(true);
            wailActive = true;
        }
    }

    IEnumerator WailForSeconds()
    {
        print("gogo");
        while (true)
        {
            if (wailActive) { 
            
                yield return new WaitForSeconds(WailOnTime);
            }
            else
            {
                yield return new WaitForSeconds(WailOffTime);
            }
            SwapWail();
        }
    }
}
