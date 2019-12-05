using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : SimpleMenu<ShopMenu>
{
    public Text MoneyText;

    new void OnEnable()
    {
        base.OnEnable();
        UpdateText();
    }

    public void UpdateText()
    {
        if (PlayerPrefs.HasKey("Money"))
            MoneyText.text = PlayerPrefs.GetInt("Money").ToString();
        else
            MoneyText.text = "0";
    }

    public override void OnBackPressed()
    {
        Hide();
        MainMenu.Show();
    }
}
