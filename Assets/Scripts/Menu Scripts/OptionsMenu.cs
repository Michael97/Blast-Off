using UnityEngine.UI;
using UnityEngine;

public class OptionsMenu : SimpleMenu<OptionsMenu>
{
    public Toggle MusicToggle;
    public Toggle SoundEffectsToggle;
    public Toggle VibrateToggle;
    public Text ChosenControlScheme;

    public string[] ControlSchemes = { "Swipe", "Swipe" };
    private int counter;

    new void OnEnable()
    {
        base.OnEnable();
        //Grab the playerprefX bools and change the toggle state
        MusicToggle.isOn = PlayerPrefsX.GetBool("MusicToggle", true);
        SoundEffectsToggle.isOn = PlayerPrefsX.GetBool("SoundEffectsToggle", true);
        VibrateToggle.isOn = PlayerPrefsX.GetBool("VibrateToggle", true);
        ChosenControlScheme.text = PlayerPrefs.GetString("ChosenControlScheme", "Swipe");
    }

    public void ChangeControlPress()
    {
        //Increase the iterator counter
        counter++;

        //If the counter is out of bounds, reset it to 0
        if (counter >= ControlSchemes.Length)
        {
            counter = 0;
        }

        //Set the text to the chosen index
        ChosenControlScheme.text = ControlSchemes[counter];
    }

    //Saves the states of the bools 
    public void OnSavePress()
    {
        PlayerPrefsX.SetBool("MusicToggle", MusicToggle.isOn);
        PlayerPrefsX.SetBool("SoundEffectsToggle", SoundEffectsToggle.isOn);
        PlayerPrefsX.SetBool("VibrateToggle", VibrateToggle.isOn);
        PlayerPrefs.SetString("ChosenControlScheme", ChosenControlScheme.text);
        OnBackPressed();
    }
}