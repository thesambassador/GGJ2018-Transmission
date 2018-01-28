using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;

public class OnOffWall : MonoBehaviour {

    public PlayerPowers activationPower;

    public bool startsUp = true;

    public Sprite upSprite;
    public Sprite downSprite;

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;

    Animator _animator;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
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

    [Button]
    void RaiseWall()
    {
        _animator.Play("RaiseWall", 0, 0);
        _animator.SetFloat("speed", 1);
        boxCollider.enabled = true;
    }
    [Button]
    void LowerWall()
    {
        _animator.Play("RaiseWall", 0, 1);
        _animator.SetFloat("speed", -1);
        boxCollider.enabled = false;
    }

    void Activate(bool powerOn)
    {
        bool up;

        if (startsUp)
            up = !powerOn;
        else
            up = powerOn;

        if (up)
        {
            RaiseWall();
            //spriteRenderer.sprite = upSprite;

        }
        else
        {
            LowerWall();
            //spriteRenderer.sprite = downSprite;
        }

        boxCollider.enabled = up;

    }

    public void Activate(PowerEventData powerOn)
    {
        Activate(powerOn.active);
    }

   
}
