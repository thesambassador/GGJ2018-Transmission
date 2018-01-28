using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSlideBlock : MonoBehaviour
{
    public float PushTime = .2f;
    private float _pushTimer = 0;

    public Vector2 slideVector;
    public bool sliding = false;
    public float slideSpeed = 2;

    Rigidbody2D _rigidbody;

    public Vector2 targetPos;

    public LayerMask slideMask;

    private TileMovement _tileMovement;

    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _tileMovement = GetComponent<TileMovement>();
        slideVector = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_tileMovement.moving && sliding && Vector2.Distance(targetPos, transform.position) > 0.01f)
        {
            sliding = _tileMovement.MoveDirection(slideVector);   
        }

        if(Vector2.Distance(targetPos, transform.position) < 0.01f)
        {
            sliding = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Level")
        {
            sliding = false;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!sliding)
            {
                _pushTimer += Time.fixedDeltaTime;
                if (_pushTimer >= PushTime)
                {
                    slideVector = VectorOppositePlayer(collision.gameObject.transform.position);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, slideVector, 3000, LayerMask.GetMask("World"));
                    if (hit.collider != null)
                    {
                        _pushTimer = 0;
                        sliding = true;
                        targetPos = hit.point - (slideVector * .5f);
                    }
                }
            }
        }
        else if (!sliding && collision.gameObject.tag == "MovingObject")
        {
            slideVector = VectorOppositePlayer(collision.contacts[0].point);
            sliding = true;
            targetPos = (Vector2)transform.position + slideVector;

        }

    }

    public Vector2 VectorOppositePlayer(Vector2 playerPos)
    {
        Vector2 diff = (Vector2)transform.position - playerPos;
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            diff.y = 0;
        }
        else
        {
            diff.x = 0;
        }
        return diff.normalized;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _pushTimer = 0;
        }
    }
}
