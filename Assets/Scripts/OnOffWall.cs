using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffWall : MonoBehaviour {

    public PlayerPowers activationPower;

    public bool startsUp = true;

    public Sprite upSprite;
    public Sprite downSprite;

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;

    // Use this for initialization
    void Start()
    {
        PlayerSongs ps = FindObjectOfType<PlayerSongs>();
        ps.AddPowerListener(activationPower, Activate);

        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        Activate(false);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Activate(bool powerOn)
    {
        bool up = startsUp && !powerOn;

        if (up)
        {
            spriteRenderer.sprite = upSprite;

        }
        else
        {
            spriteRenderer.sprite = downSprite;
        }

        boxCollider.enabled = up;

    }

    void Activate(PowerEventData powerOn)
    {
        Activate(powerOn.active);
    }

   
}
