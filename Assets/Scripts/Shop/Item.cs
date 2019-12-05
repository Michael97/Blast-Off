﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isOwned = false;
    public int price = 0;
    public Color color = Color.clear;
    public List<Sprite> animationSprites = new List<Sprite>();
}