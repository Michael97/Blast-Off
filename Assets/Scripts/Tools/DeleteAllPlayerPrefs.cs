using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAllPlayerPrefs : MonoBehaviour
{
    public bool DeleteAll;

    // Start is called before the first frame update
    void Awake()
    {
        if (DeleteAll)
            PlayerPrefs.DeleteAll();
    }

}
