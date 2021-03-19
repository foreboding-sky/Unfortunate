using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PendulumTrap : MonoBehaviour
{
    [SerializeField] private float angle = 90.0f;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float start_time = 2.0f;
    [SerializeField] private int   damage = 1;
    private TrapCollision pendulumCollider;
    Quaternion start, end;
    void Start()
    {
        start = PendulumRotation(angle);
        end = PendulumRotation(-angle);
        pendulumCollider = GetComponentInChildren<TrapCollision>();
        pendulumCollider.damage = this.damage;
    }
    void FixedUpdate()
    {
        start_time += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(start, end, (Mathf.Sin(start_time * speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    }
    void ResetTimer()
    {
        start_time = 0.0f;
    }
    Quaternion PendulumRotation(float _angle)
    {
        var pendulumRotation = transform.rotation;
        var angleZ = pendulumRotation.eulerAngles.z + _angle;

        if (angleZ > 180)
            angleZ -= 360;
        if (angleZ < -180)
            angleZ += 360;
        pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angleZ);
        return pendulumRotation;
    }
}
