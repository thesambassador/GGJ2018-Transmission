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

        FindObjectOfType<PlayerSongs>().AddPowerListener(power, ToggleText);
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
}
