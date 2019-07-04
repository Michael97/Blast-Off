//\===========================================================================================================================================
//\ Filename: ColorScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script changes the color of the attached gameobject to one of the global colors.
//\===========================================================================================================================================

using UnityEngine;

public class ColorScript : MonoBehaviour
{
    #region Public Variables

    public ColorController ColorControllerScript;
    public bool isPrimaryColor;

    #endregion


    #region Private Variables

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private new ParticleSystem particleSystem;

    #endregion


    #region Private Variables


    private void OnEnable()
    {
        //Grab the color controller from the scene
        ColorControllerScript = GameObject.FindGameObjectWithTag("ColorController").GetComponent<ColorController>();

        //Grab the particleSystem if it has one
        particleSystem = this.GetComponent<ParticleSystem>();

        if (particleSystem)
        {
            ColorChangeParticle();
        }
        else
        {
            //Grab the gameobjects sprite renderer
            spriteRenderer = this.GetComponent<SpriteRenderer>();

            if (spriteRenderer)
                ColorChange();
        }
    }

    //This method changes the color of the gameobject
    private void ColorChange()
    {
        if (isPrimaryColor)
        {
            SetColor(ColorControllerScript.PrimaryColor);
        }
        else
            SetColor(ColorControllerScript.SecondaryColor);
    }

    #endregion


    #region Public Methods

    //This method changes the color of the particle system
    public void ColorChangeParticle()
    {
        var main = particleSystem.main;

        if (isPrimaryColor)
            main.startColor = ColorControllerScript.PrimaryColor;
        else
            main.startColor = ColorControllerScript.SecondaryColor;

        particleSystem.Play();
    }


    public void SetColor(Color a_newColor)
    {
        Color newColor = spriteRenderer.color;

        newColor.b = a_newColor.b;
        newColor.r = a_newColor.r;
        newColor.g = a_newColor.g;

        Debug.Log("b : " +newColor.b);

        spriteRenderer.color = newColor;
    }


    #endregion
}
