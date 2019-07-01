using UnityEngine;
using UnityEngine.UI;

public class TextManager
{
    public ParticleSystem ParticleEffect;
    public Text TextObject;
    public string StringMessage;

    public Timer StartDelayTimer;
    public Timer EndDelayTimer;

    public bool DisplayText;


    public TextManager(Text a_TextObject, ParticleSystem a_particleSystem,
        string a_text, float a_StartDelayCount, float a_EndDelayCount)
    {
        StartDelayTimer = new Timer(a_StartDelayCount);
        EndDelayTimer = new Timer(a_EndDelayCount);

        TextObject = a_TextObject;
        ParticleEffect = a_particleSystem;

        StringMessage = a_text;

        DisplayText = true;
    }

    public void Update()
    {
        Debug.Log("we living!");

        //if displaytext == false
        if (!DisplayText)
            return; //early out

        StartDelayTimer.Update();

        if (StartDelayTimer.GetHasFinished())
        {
            EndDelayTimer.Update();

            if (!TextObject.isActiveAndEnabled)
            {
                TextObject.enabled = true;
                return;
            }

            TextObject.text = StringMessage;

            if (EndDelayTimer.GetHasFinished())
            {
                TextObject.text = "";
                TextObject.enabled = false;
                DisplayText = false;
                
            }
        }
    }
}
