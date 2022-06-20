using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPaddle : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;

    public PaddleController rightPaddle;
    public PaddleController leftPaddle;

    public float duration;

    private float timer;
    private bool isSpeedUp;
    private bool isRightSpeedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball && !isSpeedUp)
        {
            ActivateSpeedUpPaddle();
        }
    }

    private void Update()
    {
        if (isSpeedUp)
        {
            timer += Time.deltaTime;

            if (timer >= duration)
            {
                DeactivateSpeedUpPaddle();
            }
        }
    }

    private void ActivateSpeedUpPaddle()
    {
        isSpeedUp = true;
        if (ball.GetComponent<BallController>().isRight == true)
        {
            rightPaddle.SpeedUpPaddle();
            isRightSpeedUp = true;
        }
        else
        {
            leftPaddle.SpeedUpPaddle();
            isRightSpeedUp = false;
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("Paddle Speed Up!");
    }

    private void DeactivateSpeedUpPaddle()
    {
        if (isRightSpeedUp == true)
        {
            rightPaddle.DeactivateSpeedUpPaddle();
        }
        else
        {
            leftPaddle.DeactivateSpeedUpPaddle();
        }
        isSpeedUp = false;
        timer = 0;

        manager.RemovePowerUp(gameObject);
    }
}
