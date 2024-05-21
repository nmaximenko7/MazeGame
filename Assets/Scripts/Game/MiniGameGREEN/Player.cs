using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	public float movementSpeed = 7f;
	private int lastScorePositionY;

    Rigidbody2D rb;

	float movement = 0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	void Update ()
	{
		if (Mathf.RoundToInt(transform.position.y) % 10 == 0 && Mathf.RoundToInt(transform.position.y) != lastScorePositionY)
		{
			ScoreCounter.Instance.Score += 1;
			lastScorePositionY = Mathf.RoundToInt(transform.position.y);
		}
	}

	void FixedUpdate()
	{
        Vector2 velocity = rb.velocity;
        if (Input.touchCount == 1)
		{
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2) velocity.x = movementSpeed;
			else velocity.x = -movementSpeed;
			rb.velocity = velocity;
		}
        else velocity.x = 0;
        rb.velocity = velocity;
    }
}
