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
            spriteRenderer.color = ColorControllerScript.PrimaryColor;
        else
            spriteRenderer.color = ColorControllerScript.SecondaryColor;
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

    #endregion
}
