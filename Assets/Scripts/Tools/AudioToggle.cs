using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    public AudioSource audioSource;
    public string PlayerPrefsString;

    // Start is called before the first frame update
    void Update()
    {
        GetComponent<AudioSource>().enabled = PlayerPrefsX.GetBool(PlayerPrefsString, true);
    }

}
