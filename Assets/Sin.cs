using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sin : MonoBehaviour
{
    public float Frequency;
    public float Amplitude;
    public float Offset;

    private Vector3 startScale;

    private void Start()
    {
        startScale = transform.localScale;
    }
    void Update()
    {
        //transform.localPosition = new Vector3(0f, Mathf.Sin(Time.time), 0f);
        transform.localScale = startScale * (Mathf.Sin(Time.time * Frequency * 2 * Mathf.PI) * Amplitude + Offset);
    }
}
