using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject ball;
    public float speed = 5.0f;
    public GameObject paddle1Object;
    public GameObject paddle2Object;
    private Paddle paddle1;
    private Paddle paddle2;
    public Text paddle1Score;
    public Text paddle2Score;
    public Vector2 originalPosition;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // Get RigidBody2D component of Ball
        rigidBody = ball.GetComponent<Rigidbody2D>();

        // Get the paddles
        paddle1 = paddle1Object.GetComponent<Paddle>();
        paddle2 = paddle2Object.GetComponent<Paddle>();

        // Save the original position
        originalPosition = new Vector2(ball.transform.position.x, ball.transform.position.y);

        // Apply initial force
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // Increment score
        switch (collision.gameObject.tag) {
            case "Paddle1Border":
                paddle2.score++;
                paddle2Score.text = paddle2.score.ToString();
                OnScored();
                break;

            case "Paddle2Border":
                paddle1.score++;
                paddle1Score.text = paddle1.score.ToString();
                OnScored();
                break;

            case "PaddleSegment":
                switch (collision.gameObject.name) {
                    case "Top":
                        rigidBody.AddForce(new Vector2(0.0f, 1.0f), ForceMode2D.Impulse);
                        break;
                    case "Bottom":
                        rigidBody.AddForce(new Vector2(0.0f, -1.0f), ForceMode2D.Impulse);
                        break;
                }
                break;
        }
    }

    void OnScored() {
        // Reset the paddles
        paddle1.transform.position = paddle1.paddle1OriginalPosition;
        paddle2.transform.position = paddle2.paddle2OriginalPosition;

        // Reset the ball
        ball.transform.position = originalPosition;
        rigidBody.velocity = Vector2.zero;
        ApplyForce();
    }

    void ApplyForce() {
        System.Random random = new System.Random();
        List<float> directions = new List<float>{ -1.0f, 1.0f };
        int index = random.Next(directions.Count);

        rigidBody.AddForce(new Vector2(directions[index], UnityEngine.Random.Range(-1.0f, 1.0f)) * speed, ForceMode2D.Impulse);
    }
}
