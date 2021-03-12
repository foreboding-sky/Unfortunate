using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private float lerpTime = 0.1f;
    public void Shoot()
    {
        //Retracted spike y is -0.4 in localPosition
        if (this.transform.localPosition.y < 0f)
        {
            StartCoroutine(_Shoot());
        }
    }
    IEnumerator _Shoot()
    {
        float startTime = Time.time;
        Vector3 source = transform.localPosition;
        Vector3 target = new Vector3(transform.localPosition.x, transform.localPosition.y + 1f, transform.localPosition.z);

        float delay = 0f;
        //Random delay for each spike
        //delay = Random.Range(0f, 0.25f);
        yield return new WaitForSeconds(delay);

        while (Time.time < startTime + lerpTime)
        {
            transform.localPosition = Vector3.Lerp(source, target, (Time.time - startTime) / lerpTime);
            yield return null;
        }
    }
    public void Retract()
    {
        //Activated spike y is 0.6 in localPosition
        if (this.transform.localPosition.y > 0f)
        {
            StartCoroutine(_Retract());
        }
    }
    IEnumerator _Retract()
    {
        Vector3 source = transform.localPosition;
        Vector3 target = new Vector3(transform.localPosition.x, transform.localPosition.y - 1f, transform.localPosition.z);

        float delay = 0f;
        //Random delay for each spike
        //delay = Random.Range(0f, 0.15f);
        yield return new WaitForSeconds(delay);
        float startTime = Time.time;

        while (Time.time < startTime + lerpTime)
        {
            transform.localPosition = Vector3.Lerp(source, target, (Time.time - startTime) / lerpTime);
            yield return null;
        }
    }
}
