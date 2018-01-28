using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PowerEventData
{
    public PowerEventData(bool isActive, Vector2 powerPosition, float powerRadius)
    {
        playerPosition = powerPosition;
        active = isActive;
        radius = powerRadius;
    }
    public bool active;
    public Vector2 playerPosition;
    public float radius;
}

public class PowerToggleEvent : UnityEvent<PowerEventData> {}

public enum PlayerPowers
{
    Sadness = 0,
    Fear = 1,
    Anger = 2,
    Joy = 3
};

public class PlayerSongs : MonoBehaviour {

    public static bool[] unlockedPowers;

    public string[] powerButtons = { Constants.BUTTON_A, Constants.BUTTON_X, Constants.BUTTON_B, Constants.BUTTON_Y };

    public bool[] levelStartPowers;
    public bool[] activatedPowers;
    public float[] powerRanges;

    public PowerToggleEvent[] powerCallbacks;

    public CanvasGroup flashEffect;
    public Text fearText;
    public Text sadnessText;
    public Text angerText;

    int powerNumber = 3;

	// Use this for initialization
	void Awake () {
        flashEffect = GameObject.FindGameObjectWithTag("FlashEffect").GetComponent<CanvasGroup>();
        powerCallbacks = new PowerToggleEvent[powerNumber];
        for (int i = 0; i < powerNumber; i++)
        {
            powerCallbacks[i] = new PowerToggleEvent();
		}

        if (unlockedPowers == null)
        {
            unlockedPowers = new bool[powerNumber];
            for (int i = 0; i < powerNumber; i++)
            {
                unlockedPowers[i] = levelStartPowers[i];
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < powerNumber; i++){
            if(unlockedPowers[i] && Input.GetButtonDown(powerButtons[i])){
                print(i);
                TogglePower(i);
            }
        }
	}

    public void TogglePower(int powerNum)
    {
        activatedPowers[powerNum] = !activatedPowers[powerNum];
        if (powerCallbacks[powerNum] != null)
        {
            powerCallbacks[powerNum].Invoke(new PowerEventData(activatedPowers[powerNum], transform.position, powerRanges[powerNum]));
        }
    }

    public void AddPowerListener(PlayerPowers power, UnityAction<PowerEventData> action)
    {
        int powerNum = (int)power;

        powerCallbacks[powerNum].AddListener(action);

    }

    public bool IsPowerActive(PlayerPowers power)
    {
        return activatedPowers[(int)power];
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sadness")
        {
            TriggerGainPowerEffect(PlayerPowers.Sadness);
            sadnessText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Fear")
        {
            TriggerGainPowerEffect(PlayerPowers.Fear);
            fearText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Anger")
        {
            TriggerGainPowerEffect(PlayerPowers.Anger);
            angerText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }

    }

    public void TriggerGainPowerEffect(PlayerPowers powerType)
    {
        StartCoroutine("FlashScreenWhite", 5);


        unlockedPowers[(int)powerType] = true;
    }

    IEnumerator FlashScreenWhite(float fadeTime)
    {
        while (flashEffect.alpha < 1)
        {
            flashEffect.alpha += (Time.deltaTime * fadeTime);
            flashEffect.alpha = Mathf.Clamp(flashEffect.alpha, 0, 1);
            yield return null;
        }

        while (flashEffect.alpha > 0)
        {
            flashEffect.alpha -= (Time.deltaTime * fadeTime);
            flashEffect.alpha = Mathf.Clamp(flashEffect.alpha, 0, 1);
            yield return null;
        }
    }

}
