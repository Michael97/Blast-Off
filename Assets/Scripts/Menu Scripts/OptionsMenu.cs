using UnityEngine.UI;
using UnityEngine;

public class OptionsMenu : SimpleMenu<OptionsMenu>
{
    public Toggle MusicToggle;
    public Toggle SoundEffectsToggle;

    new void OnEnable()
    {
        //Grab the playerprefX bools and change the toggle state
        MusicToggle.isOn = PlayerPrefsX.GetBool("MusicToggle", true);
        SoundEffectsToggle.isOn = PlayerPrefsX.GetBool("SoundEffectsToggle", true);
    }

    //Saves the states of the bools 
    public void OnSavePress()
    {
        PlayerPrefsX.SetBool("MusicToggle", MusicToggle.isOn);
        PlayerPrefsX.SetBool("SoundEffectsToggle", SoundEffectsToggle.isOn);
        OnBackPressed();
    }
}