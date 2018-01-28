using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    Anger = 1,
    Fear = 2,
    Joy = 3
};

public class PlayerSongs : MonoBehaviour {

    public string[] powerButtons = { Constants.BUTTON_A, Constants.BUTTON_X, Constants.BUTTON_B, Constants.BUTTON_Y };

    public bool[] unlockedPowers;
    public bool[] activatedPowers;
    public float[] powerRanges;

    public PowerToggleEvent[] powerCallbacks;

	// Use this for initialization
	void Awake () {
        powerCallbacks = new PowerToggleEvent[4];
        for (int i = 0; i < 4; i++) {
            powerCallbacks[i] = new PowerToggleEvent();
		}
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < 4; i++){
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
}
