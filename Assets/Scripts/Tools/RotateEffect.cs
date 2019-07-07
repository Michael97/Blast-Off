using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEffect : MonoBehaviour
{
    public float RotateAmount;
    public float Speed;

    public float StartRotation;

    private void Start()
    {
        StartRotation = transform.localEulerAngles.z;
        StartCoroutine(ObjectRotate());
    }

    IEnumerator ObjectRotate()
    {
        float timer = 0;
        while (true)
        {
            float angle = Mathf.Sin(timer) * RotateAmount + StartRotation;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            timer += Time.deltaTime * Speed;
            yield return null;
        }
    }
}