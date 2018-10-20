using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour {

    public string side = "Left";
    public float speed = 300f;

    private Rigidbody2D rb;
    private float movement = 0;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxisRaw(side + "Move");
	}

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, movement * speed * Time.fixedDeltaTime);
    }
}
