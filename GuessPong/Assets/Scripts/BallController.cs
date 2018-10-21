using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 currentVelocity;
    private Vector2 startVelocity;
    private string side;
    private SpriteRenderer sprite;
    private bool headingRight;
    private float colorLerpStart;

    public Color leftColor;
    public Color rightColor;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        startVelocity = new Vector2(Random.Range(150f, 300f), Random.Range(0, 100f));
        currentVelocity = startVelocity;
        headingRight = currentVelocity.x > 0;
        colorLerpStart = transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 0)
        {
            side = "Right";
        } else
        {
            side = "Left";
        }

        if (headingRight)
            sprite.color = Color.Lerp(leftColor, rightColor, 1 - transform.position.x / colorLerpStart);
        else
            sprite.color = Color.Lerp(rightColor, leftColor, 1 - transform.position.x / colorLerpStart);
    }

    private void FixedUpdate()
    {
        rb.velocity = currentVelocity * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("bat"))
        {
            float addVelocity = collision.collider.GetComponent<Rigidbody2D>().velocity.y * 20;
            currentVelocity = new Vector2(-currentVelocity.x, currentVelocity.y + addVelocity);
            headingRight = !headingRight;
            colorLerpStart = transform.position.x;

        } else if (collision.collider.CompareTag("wall"))
        {
            currentVelocity = new Vector2(currentVelocity.x, -currentVelocity.y);


        } else if (collision.collider.CompareTag("leftGoal"))
        {
            GameController.Instance.AnnounceWinner("Right");

        } else if (collision.collider.CompareTag("rightGoal"))
        {
            GameController.Instance.AnnounceWinner("Left");
        }
    }

    public string GetSide()
    {
        return side;
    }
}
