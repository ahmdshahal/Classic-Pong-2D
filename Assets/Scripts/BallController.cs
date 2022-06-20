using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed;

    private Rigidbody2D rb;

    public bool isRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BallMovement();
    }

    public void BallMovement()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void ResetBallPosition()
    {
        transform.position = Vector2.zero;
        BallMovement();
    }

    public void ActivateSpeedUp(float magnitude)
    {
        rb.velocity *= magnitude;
    }

    public void DeactivateSpeedUp(float magnitude)
    {
        rb.velocity /= magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Right Paddle")
        {
            isRight = true;
        }
        if(collision.gameObject.tag == "Left Paddle")
        {
            isRight = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Out")
        {
            ResetBallPosition();
        }
    }
}