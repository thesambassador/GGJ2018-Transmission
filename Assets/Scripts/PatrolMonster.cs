using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
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

    public TileMovement _tileMovement;

    public bool stopped = false;

    public float pauseTime = 1;

    private bool moving = true;

    private Animator _animator;

    // Use this for initialization
    void Start()
    {
        PlayerSongs ps = FindObjectOfType<PlayerSongs>();
        ps.AddPowerListener(activationPower, Activate);
        currentTargetPosition = position2;
        _rigidBody = GetComponent<Rigidbody2D>();
        _tileMovement = GetComponent<TileMovement>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped && moving)
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
        StartCoroutine("StopMovingForTime");
    }

    public Vector2 VectorTowardsTarget()
    {
        Vector2 result = currentTargetPosition - (Vector2)transform.position;
        return result.normalized;
    }

    public void Activate(PowerEventData on)
    {
        if (Vector2.Distance(transform.position, on.playerPosition) < on.radius)
        {
            stopped = on.active;
        }

        if (stopped)
        {
            _animator.SetTrigger("Freeze");
        }
        else
        {
            _animator.SetTrigger("Unfreeze");
        }
    }

    IEnumerator StopMovingForTime()
    {
        moving = false;
        yield return new WaitForSeconds(pauseTime);
        moving = true;
    }

    [Button]
    public void SetPosition1()
    {
        position1 = transform.position;
        EditorUtility.SetDirty(this);
    }

    [Button]
    public void SetPosition2()
    {
        position2 = transform.position;
        EditorUtility.SetDirty(this);
    }

    public void OnCollisionEnter2D(Collision2D collision) { 
    
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
