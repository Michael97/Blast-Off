//\===========================================================================================================================================
//\ Filename: PlayerControllerScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script controls the player movement
//\===========================================================================================================================================

using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{

    #region Public Variables

    public float MovementSpeed;
    public Item item;

    public List<Sprite> listSprites;

    public float HortizontalDirection;
    public float VerticalDirection;

    public SpriteRenderer currentSprite;

    public enum Movement
    {
        Left,
        Right,
        Neutral
    }

    public Movement movement;

    

    #endregion


    #region Private Variables

    private void FixedUpdate()
    { 
        MoveDirection();
    }

    public void Animations()
    {
        switch(movement)
        {
            case Movement.Left:
                currentSprite.sprite = item.animationSprites[1];
                currentSprite.sprite = item.animationSprites[0];
                break;
            case Movement.Right:
                currentSprite.sprite = item.animationSprites[3];
                currentSprite.sprite = item.animationSprites[4];
                break;
            case Movement.Neutral:
                currentSprite.sprite = item.animationSprites[2];
                break;
            default:
                break;
       
        }
    }

    //Updates the position of the object
    private void MoveDirection()
    {
        gameObject.transform.position += new Vector3(HortizontalDirection * MovementSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    public void SetSprites()
    {
        /*
        string baseSpriteName = item.icon.name;
        baseSpriteName = baseSpriteName.Substring(0, baseSpriteName.Length - 2);
        Debug.Log(baseSpriteName);
        for (int i = 0; i <= 5; ++i)
        {
            listSprites[i] = Resources.Load<Sprite>($"{baseSpriteName}_{i}");
        }
        */

    }

    #endregion
}
