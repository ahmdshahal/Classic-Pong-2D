using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int maxSize;
    [SerializeField] int minSize;
    [SerializeField] int maxSpeed;
    [SerializeField] int minSpeed;
    [SerializeField] KeyCode upKey;
    [SerializeField] KeyCode downKey;

    private Rigidbody2D rb;

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveObject(GetInput());

        //Limit paddle speed and paddle size
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        transform.localScale = new Vector3(0.3f, Mathf.Clamp(transform.localScale.y, minSize, maxSize), 1);

        Debug.Log(speed);
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        rb.velocity = movement;
    }

    public void ExtendPaddle()
    {        
        transform.localScale += new Vector3(0, 2);
    }

    public void ShortenPaddle()
    {
        transform.localScale -= new Vector3(0, 2);
    }

    public void SpeedUpPaddle()
    {
        speed += 5;
    }

    public void DeactivateSpeedUpPaddle()
    {
        speed -= 5;
    }    
}
