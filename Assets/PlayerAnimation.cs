using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public float minVelForAnim = 1;

    Rigidbody2D _rigidbody;
    Animator _animator;

    string animLeft = "MoveLeft";
    string animRight = "MoveRight";
    string animUp = "MoveUp";
    string animDown = "MoveDown";

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 vel = _rigidbody.velocity;

        if (vel.magnitude > minVelForAnim)
        {

            if (Mathf.Abs(vel.x) > Mathf.Abs(vel.y))
            {
                if (vel.x > 0)
                {
                    //print("right");
                    _animator.SetBool(animUp, false);
                    _animator.SetBool(animDown, false);
                    _animator.SetBool(animLeft, false);
                    _animator.SetBool(animRight, true);
                }
                else
                {
                    //print("left");
                    _animator.SetBool(animUp, false);
                    _animator.SetBool(animDown, false);
                    _animator.SetBool(animLeft, true);
                    _animator.SetBool(animRight, false);
                }
            }
            else
            {
                if (vel.y > 0)
                {
                    _animator.SetBool(animUp, true);
                    _animator.SetBool(animDown, false);
                    _animator.SetBool(animLeft, false);
                    _animator.SetBool(animRight, false);
                }
                else 
                {
                    _animator.SetBool(animUp, false);
                    _animator.SetBool(animDown, true);
                    _animator.SetBool(animLeft, false);
                    _animator.SetBool(animRight, false);
                }
            }
        }
        else
        {
            _animator.SetBool(animUp, false);
            _animator.SetBool(animDown, false);
            _animator.SetBool(animLeft, false);
            _animator.SetBool(animRight, false);
        }


	}
}
