using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	public GameObject paddle1;
	public GameObject paddle2;
	private AudioSource audioSource;
	public int score = 0;
	public GameObject ballObject;
	private Ball ball;
	public Vector2 paddle1OriginalPosition;
	public Vector2 paddle2OriginalPosition;

	// Start is called before the first frame update
	void Start()
	{
		// Get the ball
		ball = ballObject.GetComponent<Ball>();

		// Save the original positions
		paddle1OriginalPosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
		paddle2OriginalPosition = new Vector2(paddle2.transform.position.x, paddle2.transform.position.y);
	}

	// Update is called once per frame
	void Update()
	{
		// Paddle 1 controls
		paddle1.transform.Translate(new Vector3(0f, Input.GetAxis("Paddle1") * Time.deltaTime * ball.speed));

		// Padle 2 controls
		paddle2.transform.Translate(new Vector3(0f, Input.GetAxis("Paddle2") * Time.deltaTime * ball.speed));
	}
}
