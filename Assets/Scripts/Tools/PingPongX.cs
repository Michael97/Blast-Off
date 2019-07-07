using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongX : MonoBehaviour
{
    public Vector3 Point1;
    public Vector3 Point2;
    public float speed;

    private void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(Point1, Point2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
