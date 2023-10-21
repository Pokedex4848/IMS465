using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public variables
    public Rigidbody2D rb;
    public float hSpeed, vSpeed;

    //Private variables
    private float hDirection, vDirection;
    private float idleTime = 0;
    private int idleCheck = 0;
    private bool idleIncrease;
    private Vector3 idlePosition;

    // Update is called once per frame
    void Update()
    {
        hDirection = Input.GetAxis("Horizontal");
        vDirection = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (hDirection * hSpeed, vDirection * vSpeed);

        if (Mathf.Abs(hDirection) < 0.001 && Mathf.Abs(vDirection) < 0.001)
        {
            if(idleCheck == 0)
            {
                idleCheck = 1;
                idlePosition = transform.position;
                idleTime = 0.5f;
            }

            Idle();
        }
        else
        {
            idleCheck = 0;
        }
    }

    private void Idle()
    {
        if(idleTime >= 1)
        {
            idleIncrease = false;
        }
        else if(idleTime <= 0)
        {
            idleIncrease = true;
        }

        if(idleIncrease)
        {
            idleTime += 0.05f;
        }
        else if (!idleIncrease)
        {
            idleTime -= 0.05f;
        }

        transform.position = new Vector3(transform.position.x, Mathf.Lerp(idlePosition.y + 0.05f, idlePosition.y - 0.05f, idleTime), transform.position.z);
    }
}
