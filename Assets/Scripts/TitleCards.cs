using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCards : MonoBehaviour {

    CanvasGroup[] groups;

    public int currentIndex = 0;

    public float fadeTime = 1;
    public float pauseTime = 2;

    public bool faded;

	// Use this for initialization
	void Start () {
        groups = new CanvasGroup[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            CanvasGroup newGroup = transform.GetChild(i).GetComponent<CanvasGroup>();
            groups[i] = newGroup;
            newGroup.alpha = 0;
        }

        if (currentIndex < groups.Length)
        {
            StartCoroutine("FadeIn");
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey && faded)
        {
            StartCoroutine("FadeOut");
        }
	}

    IEnumerator FadeIn()
    {
        float alpha = 0;
        float time = 0;
        while (alpha < 1)
        {
            time += Time.deltaTime;
            alpha = time / fadeTime;
            alpha = Mathf.Clamp(alpha, 0, 1);
            groups[currentIndex].alpha = alpha;
            yield return null;
        }

        faded = true;
    }

    IEnumerator FadePause()
    {
        yield return new WaitForSeconds(pauseTime);
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        faded = false;
        float alpha = 0;
        float time = 0;
        while (groups[currentIndex].alpha > 0)
        {
            time += Time.deltaTime;
            alpha = 1 - (time / fadeTime);
            alpha = Mathf.Clamp(alpha, 0, 1);
            groups[currentIndex].alpha = alpha;
            yield return null;
        }
        currentIndex += 1;
        if (currentIndex < groups.Length)
        {
            StartCoroutine("FadeIn");
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
