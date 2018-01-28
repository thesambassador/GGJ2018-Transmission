using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MoveObjectOnPower : MonoBehaviour {

    public PlayerPowers activationPower;
    public Vector2 position1;
    public Vector2 position2;

    public Vector2 currentTargetPosition;

    public float moveSpeed = 2;

    public Rigidbody2D _rigidBody;

	// Use this for initialization
	void Start () {
        PlayerSongs ps = FindObjectOfType<PlayerSongs>();
        ps.AddPowerListener(activationPower, Activate);
        currentTargetPosition = position1;
        Rigidbody2D _rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector2.MoveTowards(transform.position, currentTargetPosition, moveSpeed * Time.deltaTime);

        _rigidBody.MovePosition(Vector2.MoveTowards(transform.position, currentTargetPosition, moveSpeed * Time.deltaTime));
	}

    public void Activate(PowerEventData on)
    {
        if (on.active)
        {
            currentTargetPosition = position2;
        }
        else
        {
            currentTargetPosition = position1;
        }
    }

    [Button]
    public void SetPosition1()
    {
        position1 = transform.position;
    }

    [Button]
    public void SetPosition2()
    {
        position2 = transform.position;
    }
}
