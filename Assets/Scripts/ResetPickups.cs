using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPickups : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        //Resets the pickup for the prefab
        //Null check
        if (gameObject.transform.Find("Pickup") != null)
            gameObject.transform.Find("Pickup").gameObject.SetActive(true);
    }
}
