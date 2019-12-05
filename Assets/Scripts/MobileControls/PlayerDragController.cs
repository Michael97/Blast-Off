using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragController : BaseMobileController
{
    private bool m_can_move;

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 4.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerControllerScript = GetComponent<PlayerController>();
    }

    public void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //Grab the touch location
            touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

            //touchPosition.y += 2.0f;
            direction = touchPosition - transform.position;

            if (direction.x >= 0.3)
            {
                PlayerControllerScript.movement = PlayerController.Movement.Right;
            }
            else if (direction.x <= -0.3)
            {
                PlayerControllerScript.movement = PlayerController.Movement.Left;
            }
            else
            {
                PlayerControllerScript.movement = PlayerController.Movement.Neutral;
            }


            rb.velocity = new Vector2(direction.x, direction.y + 1.5f) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                PlayerControllerScript.movement = PlayerController.Movement.Neutral;
                rb.velocity = Vector2.zero;
            }

            PlayerControllerScript.Animations();
        }
    }


    


}
