using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    [SerializeField] private List<Vector3> points;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float waitTime = 1f;
    private bool isMoving = false;
    private float startTime;
    private Vector3 source;
    void Update()
    {
        if (!isMoving)
            StartCoroutine(MovePlatform());
    }
    IEnumerator MovePlatform()
    {
        isMoving = true;
        for (int i = 0; i < points.Count; i++)
        {
            startTime = Time.time;
            source = transform.localPosition;
            while (Time.time < startTime + LerpTime(source, points[i]))
            {
                transform.localPosition = Vector3.Lerp(source, points[i], (Time.time - startTime) / LerpTime(source, points[i]));
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);
        }
        for (int i = points.Count - 1; i >= 0; i--)
        {
            startTime = Time.time;
            source = transform.localPosition;
            while (Time.time < startTime + LerpTime(source, points[i]))
            {
                transform.localPosition = Vector3.Lerp(source, points[i], (Time.time - startTime) / LerpTime(source, points[i]));
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);
        }
        isMoving = false;
        yield return null;
    }
    private float LerpTime(Vector3 first, Vector3 second)
    {
        float res = (first - second).magnitude;
        return res / speed;
    }
}
