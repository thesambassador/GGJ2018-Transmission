using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerText : MonoBehaviour {

    Text textComponent;

    public string powerName;

    public PlayerPowers power;

	// Use this for initialization
	void Start () {
        textComponent = GetComponent<Text>();

        PlayerSongs songs = FindObjectOfType<PlayerSongs>();
        songs.AddPowerListener(power, ToggleText);
        ToggleText(songs.IsPowerActive(power));
	}
	
    void ToggleText(bool active)
    {
        if (active)
        {
            textComponent.text = powerName + ": On";
        }
        else
        {
            textComponent.text = powerName + ": Off";
        }
    }

    void ToggleText(PowerEventData active)
    {
        ToggleText(active.active);
    }
}
