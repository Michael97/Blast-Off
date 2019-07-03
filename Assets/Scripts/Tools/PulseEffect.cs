using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseEffect : MonoBehaviour
{
    public float scaleMax;
    public Vector3 tempScale;
    public float speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        tempScale = transform.localScale;

        tempScale.x = Mathf.PingPong(Time.time * speed, scaleMax) + 1.0f;
        tempScale.y = tempScale.x;

        transform.localScale = tempScale;
    }
}
