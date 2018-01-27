using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Rigidbody2D _rigidBody;


	// Use this for initialization
	void Start () {
        _rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 movementVector = GetJoystickInput() * speed;

        _rigidBody.velocity = movementVector;

	}

    Vector2 GetJoystickInput()
    {
        Vector2 result = Vector2.zero;

        //result.x = Input.GetAxisRaw("Horizontal");
        //result.y = Input.GetAxisRaw("Vertical");

        result.x = Input.GetAxis("Horizontal");
        result.y = Input.GetAxis("Vertical");

        return result;
    }
}
