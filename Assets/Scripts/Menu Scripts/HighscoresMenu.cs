using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoresMenu : SimpleMenu<HighscoresMenu>
{
    public override void OnBackPressed()
    {
        Hide();
        //Destroy(gameObject); // This menu does not automatically destroy itself
        //MainMenu.Show();
    }
}
