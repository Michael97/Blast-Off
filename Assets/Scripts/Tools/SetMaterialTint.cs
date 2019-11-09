//\===========================================================================================================================================
//\ Filename: SetMaterialTint.cs
//\ Author  : Michael Thomas
//\ Date    : 07/11/2019
//\ Brief   : Sets the color and alpha of a custom material.
//\===========================================================================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialTint : MonoBehaviour
{
    public Material mat;
    public ColorController colorScript;
    public float alpha;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void UpdateColor()
    {
        colorScript = GameObject.FindGameObjectWithTag("ColorController").GetComponent<ColorController>();

        if (colorScript == null)
            return;

        mat = GetComponent<Renderer>().sharedMaterial;

        if (mat == null)
            return;

        SetNewColors(colorScript.PrimaryColor, colorScript.SecondaryColor, colorScript.ThirdColor);

        if (alpha != 1.0f)
        {
            Color primary = new Color(colorScript.PrimaryColor.r, colorScript.PrimaryColor.g, colorScript.PrimaryColor.b, alpha);
            Color secondary = new Color(colorScript.SecondaryColor.r, colorScript.SecondaryColor.g, colorScript.SecondaryColor.b, alpha);
            Color third = new Color(colorScript.ThirdColor.r, colorScript.ThirdColor.g, colorScript.ThirdColor.b, alpha);

            SetNewColors(primary, secondary, third);
        }
    }

    void SetNewColors(Color primary, Color secondary, Color third)
    {
        mat.SetColor("_TintColorRed", primary);
        mat.SetColor("_TintColorGreen", secondary);
        mat.SetColor("_TintColorBlue", third);
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
