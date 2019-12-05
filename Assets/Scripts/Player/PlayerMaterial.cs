//\===========================================================================================================================================
//\ Filename: SetMaterialTint.cs
//\ Author  : Michael Thomas
//\ Date    : 07/11/2019
//\ Brief   : Sets the color and alpha of a custom material.
//\===========================================================================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterial : MonoBehaviour
{
    public Material mat;
    public Color PrimaryColor;
    public Color SecondaryColor;
    public Color ThirdColor;
    public float alpha;

    public void SetNewMat(Material _mat)
    {
        mat = _mat;
    }

    public void UpdateColor()
    {
        mat = GetComponent<Renderer>().sharedMaterial;

        PrimaryColor = mat.GetColor("_TintColorRed");
        SecondaryColor = mat.GetColor("_TintColorGreen");
        ThirdColor = mat.GetColor("_TintColorBlue");


        if (mat == null)
            return;

        Color primary = new Color(PrimaryColor.r, PrimaryColor.g, PrimaryColor.b, alpha);
        Color secondary = new Color(SecondaryColor.r, SecondaryColor.g, SecondaryColor.b, alpha);
        Color third = new Color(ThirdColor.r, ThirdColor.g, ThirdColor.b, alpha);

        SetNewColors(primary, secondary, third);
    }

    void SetNewColors(Color primary, Color secondary, Color third)
    {
        mat.SetColor("_TintColorRed", primary);
        mat.SetColor("_TintColorGreen", secondary);
        mat.SetColor("_TintColorBlue", third);
    }

    //This is like probably the worse way to make the character flicker. I need to make this better at some point. Possibly just make it an animation or something.
    public IEnumerator Fade()
    {
        InvokeRepeating("Flicker", 0, Random.Range(0.4f, 1.0f));

        yield return new WaitForSeconds(2.0f);
        CancelInvoke("Flicker");
        alpha = 1.0f;
        GetComponent<PlayerController>().entityState = EntityState.State.Alive;
        GetComponent<Collider2D>().enabled = true;
        UpdateColor();
    }

    private void Flicker()
    {
        alpha = 0f;
        UpdateColor();
        Invoke("HitFade", 0.05f);
    }

    private void HitFade()
    {
        alpha = 0.2f;
        UpdateColor();
    }
}
