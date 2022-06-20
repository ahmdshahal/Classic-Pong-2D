using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;

    public float magnitude;
    public float duration;

    private bool isSpeedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball && !isSpeedUp)
        {
            ActivateSpeedUp();
        }        
    }

    private void ActivateSpeedUp()
    {
        ball.GetComponent<BallController>().ActivateSpeedUp(magnitude);
        isSpeedUp = true;
        manager.RemovePowerUp(gameObject);
        Debug.Log("Speed Up!");
    }
}
