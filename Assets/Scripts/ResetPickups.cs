using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPickups : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        //Resets the pickup for the prefab
        gameObject.transform.Find("Pickup").gameObject.SetActive(true);
    }
}
