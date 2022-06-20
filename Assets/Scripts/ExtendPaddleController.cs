using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendPaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;

    public PaddleController rightPaddle;
    public PaddleController leftPaddle;

    public float duration;

    private float timer;
    private bool isExtend = false;
    private bool isRightExtend;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == ball)
        {
            ActivateExtendPaddle();
        }
    }

    private void Update()
    {
        if (isExtend)
        {
            timer += Time.deltaTime;

            if (timer >= duration)
            {
                DeactivateExtendPaddle();
            }
        }
    }

    private void ActivateExtendPaddle()
    {
        isExtend = true;
        if (ball.GetComponent<BallController>().isRight == true)
        {
            rightPaddle.ExtendPaddle();
            isRightExtend = true;
        }
        else
        {
            leftPaddle.ExtendPaddle();
            isRightExtend = false;
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("Paddle Extended");
    }

    private void DeactivateExtendPaddle()
    {
        if (isRightExtend == true)
        {
            rightPaddle.ShortenPaddle();
        }
        else
        {
            leftPaddle.ShortenPaddle();
        }
        isExtend = false;
        timer = 0;

        manager.RemovePowerUp(gameObject);
    }
}
