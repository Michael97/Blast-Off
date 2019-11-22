using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragController : BaseMobileController
{
    private bool m_can_move;

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 3.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

            rb.velocity = new Vector2(direction.x, direction.y + 2.0f) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }
    }
    


}
