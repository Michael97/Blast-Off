using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BOVibrate
{
    public static void Vibrate()
    {
        if (PlayerPrefsX.GetBool("VibrateToggle", true))
            Handheld.Vibrate();
    }


}
