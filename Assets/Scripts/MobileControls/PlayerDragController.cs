using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragController : BaseMobileController
{
    private bool m_can_move;

    public void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //Grab the touch location
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

            //Get the move postion and lock its Y pos
            Vector3 movePosition = new Vector3(touchPosition.x, gameObject.transform.position.y, touchPosition.z);

            //if we touched too far from the player, do anything
            if (m_can_move == false)
                if (Vector3.Distance(movePosition, this.transform.position) < 0.4f)
                    m_can_move = true;

            //If the player touched close enough to the sprite we move it.
            if (m_can_move)
                this.transform.position = Vector3.Lerp(this.transform.position, movePosition, 1.0f);

        }
        else
            m_can_move = false;
    }

}
