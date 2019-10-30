using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialTint : MonoBehaviour
{
    public Material mat;
    public ColorController colorScript;

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

        mat.SetColor("_TintColorRed", colorScript.PrimaryColor);
        mat.SetColor("_TintColorGreen", colorScript.SecondaryColor);
        mat.SetColor("_TintColorBlue", colorScript.ThirdColor);
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
