using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PatrolMonster : MonoBehaviour
{

    public PlayerPowers activationPower;
    bool goalIsPosition1 = false;
    public Vector2 position1;
    public Vector2 position2;

    public Vector2 currentTargetPosition; //the next adjaent tile that we're trying to move to.

    public float moveSpeed = 2;

    public Rigidbody2D _rigidBody;

    public LayerMask raycastMask;

    private TileMovement _tileMovement;

    public bool stopped = false;

    // Use this for initialization
    void Start()
    {
        PlayerSongs ps = FindObjectOfType<PlayerSongs>();
        ps.AddPowerListener(activationPower, Activate);
        currentTargetPosition = position2;
        _rigidBody = GetComponent<Rigidbody2D>();
        _tileMovement = GetComponent<TileMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!stopped)
        {
            if (!_tileMovement.moving)
            {
                if (Vector2.Distance(transform.position, currentTargetPosition) < .001f)
                {
                    SwapTargetPosition();
                }
                else if (!_tileMovement.MoveDirection(VectorTowardsTarget()))
                {
                    SwapTargetPosition();
                }
            }
        }
        //transform.position = Vector2.MoveTowards(transform.position, currentTargetPosition, moveSpeed * Time.deltaTime);

       // _rigidBody.MovePosition(Vector2.MoveTowards(transform.position, currentTargetPosition, moveSpeed * Time.deltaTime));
    }

    void SwapTargetPosition()
    {
        if (goalIsPosition1)
        {
            currentTargetPosition = position2;
        }
        else
        {
            currentTargetPosition = position1;
        }

        goalIsPosition1 = !goalIsPosition1;

    }

    public Vector2 VectorTowardsTarget()
    {
        Vector2 result = currentTargetPosition - (Vector2)transform.position;
        return result.normalized;
    }

    void Activate(PowerEventData on)
    {
        if (Vector2.Distance(transform.position, on.playerPosition) < on.radius)
        {
            stopped = on.active;
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
