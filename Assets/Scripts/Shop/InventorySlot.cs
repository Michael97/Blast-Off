﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image image;
    public Text priceText;
    public Item item;
    public Image chosenImage;

    public PlayerSpawner playerSpawner;

    private void Update()
    {
        if (playerSpawner.ChosenPlayerItem != item && chosenImage.enabled == true)
            chosenImage.enabled = false;
    }

    private void OnEnable()
    {
        playerSpawner = GameObject.FindGameObjectWithTag("PlayerSpawner").GetComponent<PlayerSpawner>();
        image.sprite = item.icon;
        image.color = item.color;
        if (playerSpawner.ChosenPlayerItem == item)
            chosenImage.enabled = true;
        else
            chosenImage.enabled = false;
        Debug.Log($"{item.isOwned}");

        if (item.isOwned)
        {
            SetAlpha(1.0f);
            priceText.text = "Owned";
        }
        else
        {
            SetAlpha(0.4f);
            priceText.text = item.price.ToString();
        }
    }

    public void OnThisPressed()
    {
        //If we dont own the item
        if (item.isOwned == false)
        {
            Debug.Log("we dont own it");
            //if we have the money
            if (PlayerPrefs.GetInt("Money") >= item.price)
            {
                //Buy it
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - item.price);
                PlayerPrefsX.SetBool(item.name, true);
                item.isOwned = true;
                priceText.text = "Owned";
                SetAlpha(1.0f);
                GameObject.FindGameObjectWithTag("ShopMenu").GetComponent<ShopMenu>().UpdateText();
                Debug.Log("We own it!");
            }
        }

        if (item.isOwned == true)
        {
            playerSpawner.ChosenPlayerItem = item;
            chosenImage.enabled = true;
        }
    }

    private void SetAlpha(float a_alpha)
    {
        Color tempColor = image.color;

        tempColor.a = a_alpha;

        image.color = tempColor;
    }
}