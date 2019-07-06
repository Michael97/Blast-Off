using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : SimpleMenu<ShopMenu>
{
    public Text MoneyText;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Money"))
            MoneyText.text = PlayerPrefs.GetInt("Money").ToString();
    }

    public override void OnBackPressed()
    {
        Hide();
        MainMenu.Show();
    }
}
