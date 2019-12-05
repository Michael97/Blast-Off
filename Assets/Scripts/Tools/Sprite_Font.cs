using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Sprite_Font : MonoBehaviour
{
    public GameObject letterObject;
    public GameObject letterContainer;

    public SpriteAtlas spriteAtlas;

    public string stringToShow;

    private Sprite[] sprites;

    private void Start()
    {
        sprites = new Sprite[spriteAtlas.spriteCount];
        Array.Reverse(sprites);
        spriteAtlas.GetSprites(sprites);
        ConvertStringToSprites(stringToShow);
    }

    private void ConvertStringToSprites(string stringToConvert)
    {
        stringToConvert = stringToConvert.ToLower();
        for (int i = 0; i < stringToConvert.Length; ++i)
        {
            GameObject newLetter = Instantiate(letterObject, letterContainer.transform);
            newLetter.GetComponent<SpriteRenderer>().sprite = GetSpriteForChar(stringToConvert[i]);
            
        }
        letterContainer.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, stringToConvert.Length * sprites[0].rect.width / sprites[0].pixelsPerUnit / 1.5f);
    }

    private Sprite GetSpriteForChar(char character)
    {
        switch (character)
        {
            case 'a':
                return spriteAtlas.GetSprite("BO_Font_Full_0");
            case 'b':
                return spriteAtlas.GetSprite("BO_Font_Full_1");
            case 'c':
                return spriteAtlas.GetSprite("BO_Font_Full_2");
            case 'd':
                return spriteAtlas.GetSprite("BO_Font_Full_3");
            case 'e':
                return spriteAtlas.GetSprite("BO_Font_Full_4");
            case 'f':
                return spriteAtlas.GetSprite("BO_Font_Full_5");
            case 'g':
                return spriteAtlas.GetSprite("BO_Font_Full_6");
            case 'h':
                return spriteAtlas.GetSprite("BO_Font_Full_7");
            case 'i':
                return spriteAtlas.GetSprite("BO_Font_Full_8");
            case 'j':
                return spriteAtlas.GetSprite("BO_Font_Full_9");
            case 'k':
                return spriteAtlas.GetSprite("BO_Font_Full_10");
            case 'l':
                return spriteAtlas.GetSprite("BO_Font_Full_11");
            case 'm':
                return spriteAtlas.GetSprite("BO_Font_Full_12");
            case 'n':
                return spriteAtlas.GetSprite("BO_Font_Full_13");
            case 'o':
                return spriteAtlas.GetSprite("BO_Font_Full_14");
            case 'p':
                return spriteAtlas.GetSprite("BO_Font_Full_15");
            case 'q':
                return spriteAtlas.GetSprite("BO_Font_Full_16");
            case 'r':
                return spriteAtlas.GetSprite("BO_Font_Full_17");
            case 's':
                return spriteAtlas.GetSprite("BO_Font_Full_18");
            case 't':
                return spriteAtlas.GetSprite("BO_Font_Full_19");
            case 'u':
                return spriteAtlas.GetSprite("BO_Font_Full_20");
            case 'v':
                return spriteAtlas.GetSprite("BO_Font_Full_21");
            case 'w':
                return spriteAtlas.GetSprite("BO_Font_Full_22");
            case 'x':
                return spriteAtlas.GetSprite("BO_Font_Full_23");
            case 'y':
                return spriteAtlas.GetSprite("BO_Font_Full_24");
            case 'z':
                return spriteAtlas.GetSprite("BO_Font_Full_25");
            case '0':
                return spriteAtlas.GetSprite("BO_Font_Full_26");
            case '1':
                return spriteAtlas.GetSprite("BO_Font_Full_27");
            case '2':
                return spriteAtlas.GetSprite("BO_Font_Full_28");
            case '3':
                return spriteAtlas.GetSprite("BO_Font_Full_29");
            case '4':
                return spriteAtlas.GetSprite("BO_Font_Full_30");
            case '5':
                return spriteAtlas.GetSprite("BO_Font_Full_31");
            case '6':
                return spriteAtlas.GetSprite("BO_Font_Full_32");
            case '7':
                return spriteAtlas.GetSprite("BO_Font_Full_33");
            case '8':
                return spriteAtlas.GetSprite("BO_Font_Full_34");
            case '9':
                return spriteAtlas.GetSprite("BO_Font_Full_35");
            case ' ':
                return null;
            default:
                return null;
        }
    }
}
