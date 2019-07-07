using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseEffect : MonoBehaviour
{
    public float scaleMax;
    public float scaleMin;

    public Vector3 tempScale;

    public float speed;

    public bool isIncreasing;

    private float scaleFactor;

    private void Start()
    {
        scaleFactor = transform.localScale.x / transform.localScale.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isIncreasing == true)
            Increase();
        else
            Decrease();


    }

    private void Increase()
    {
        tempScale = transform.localScale;

        tempScale.x += Time.deltaTime * speed;
        tempScale.y += Time.deltaTime * speed / scaleFactor;

        if (tempScale.x >= scaleMax)
            isIncreasing = false;

        transform.localScale = tempScale;
    }

    private void Decrease()
    {
        tempScale = transform.localScale;

        tempScale.x -= Time.deltaTime * speed;
        tempScale.y -= Time.deltaTime * speed / scaleFactor;

        if (tempScale.x <= scaleMin)
            isIncreasing = true;

        transform.localScale = tempScale;
    }
}
