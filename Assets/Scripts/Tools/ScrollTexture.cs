using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float ScrollX;
    public float ScrollY;

    // Update is called once per frame
    void Update()
    {
        float OffsetX = Time.time * ScrollX;
        float OffsetY = Time.time * ScrollY;
        GetComponent<SpriteRenderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }
}
