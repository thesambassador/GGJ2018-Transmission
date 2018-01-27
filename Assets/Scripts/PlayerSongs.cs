using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerToggleEvent : UnityEvent<bool>{}

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
            powerCallbacks[powerNum].Invoke(activatedPowers[powerNum]);
        }
    }

    public void AddPowerListener(PlayerPowers power, UnityAction<bool> action)
    {
        int powerNum = (int)power;

        powerCallbacks[powerNum].AddListener(action);

    }
}
