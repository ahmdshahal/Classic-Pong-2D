using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BallMovement();
    }

    private void BallMovement()
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
}
