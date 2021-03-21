using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
    public Text point_counter;

    private void Update()
    {
        point_counter.text = $"{ FortunePoints.instance.CheckPoints()}";
    }
}
