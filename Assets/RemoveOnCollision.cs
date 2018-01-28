﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnCollision : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingObject")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
