using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSTarget : MonoBehaviour
{

    public int Target = 30;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = Target;
    }

    void Update()
    {
        if (Application.targetFrameRate != Target)
            Application.targetFrameRate = Target;
    }
}