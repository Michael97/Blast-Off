//\===========================================================================================================================================
//\ Filename: ColorController.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : A script that handles the 2 colors of the current zone, this can change on each zone change.
//\===========================================================================================================================================

using UnityEngine;

public class ColorController : MonoBehaviour
{
    #region Public Variables

    public Color PrimaryColor;
    public Color SecondaryColor;

    #endregion


    #region Public Methods

    public void ChangeColor()
    {
        PrimaryColor = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f);
        SecondaryColor = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f);
    }

    #endregion
}
