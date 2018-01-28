using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelOnTriggerEnter : MonoBehaviour {

    public int buildNumber = 0;

    public bool justDoNextBuildNumber = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int nextSceneIndex = buildNumber;
            if (justDoNextBuildNumber)
            {
                nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            }
            print(nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex);

        }
    }
}
