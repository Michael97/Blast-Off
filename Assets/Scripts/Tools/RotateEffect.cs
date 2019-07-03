using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEffect : MonoBehaviour
{
    public float RotateMax;
    public float Speed;

    private void FixedUpdate()
    {
        Vector3 tempEuler = new Vector3();

        tempEuler.z = Mathf.PingPong(Time.time * Speed, RotateMax) - (RotateMax/2);

        transform.eulerAngles = tempEuler;
    }
}
