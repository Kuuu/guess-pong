using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 currentVelocity;
    private Vector2 startVelocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        startVelocity = new Vector2(200f, 50f);
        currentVelocity = startVelocity;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        rb.velocity = currentVelocity * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision..");

        if (collision.collider.CompareTag("bat"))
        {
            Debug.Log("..Collision with bat");
            currentVelocity = new Vector2(-currentVelocity.x, currentVelocity.y);
        } else if (collision.collider.CompareTag("wall"))
        {
            Debug.Log("..Collision with wall");
            currentVelocity = new Vector2(currentVelocity.x, -currentVelocity.y);
        }
    }
}
