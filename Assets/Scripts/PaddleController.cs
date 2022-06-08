using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] KeyCode upKey;
    [SerializeField] KeyCode downKey;

    private Rigidbody2D rb;

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveObject(GetInput()); 
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
}
