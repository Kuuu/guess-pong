﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour {

    public string side = "Left";
    public float speed = 300f;

    private Rigidbody2D rb;
    private float movement = 0;

    private bool isFrozen = false;
    //private bool returning = false;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isFrozen)
        {
            if (GameController.Instance.ballController.GetSide() != side)
            {
                movement = Input.GetAxisRaw(side + "Move");
            }
            if (movement != 0)
            {
                isFrozen = true;
            }
        }
	}

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, movement * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("corner"))
        {
            movement = -movement;
        } else if (collision.collider.CompareTag("ball"))
        {
            movement = 0;
            isFrozen = false;
        }
    }
}
