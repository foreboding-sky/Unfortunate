﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float lerpTime = 0.1f;
    private Vector3 targetUp, targetDown;

    private void Start()
    {
        targetDown = transform.localPosition;
        targetUp = new Vector3(transform.localPosition.x, transform.localPosition.y + 1f, transform.localPosition.z);
    }
    public void Shoot()
    {
        StartCoroutine(_Shoot());
    }
    IEnumerator _Shoot()
    {
        float startTime = Time.time;
        Vector3 source = transform.localPosition;

        float delay = 0f;
        //Random delay for each spike
        //delay = Random.Range(0f, 0.25f);
        yield return new WaitForSeconds(delay);

        while (Time.time < startTime + lerpTime)
        {
            transform.localPosition = Vector3.Lerp(source, targetUp, (Time.time - startTime) / lerpTime);
            yield return null;
        }
    }
    public void Retract()
    {
        StartCoroutine(_Retract());
    }
    IEnumerator _Retract()
    {
        Vector3 source = transform.localPosition;

        float delay = 0f;
        //Random delay for each spike
        //delay = Random.Range(0f, 0.15f);
        yield return new WaitForSeconds(delay);
        float startTime = Time.time;

        while (Time.time < startTime + lerpTime)
        {
            transform.localPosition = Vector3.Lerp(source, targetDown, (Time.time - startTime) / lerpTime);
            yield return null;
        }
    }
}
